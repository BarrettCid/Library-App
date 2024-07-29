import { Component, OnInit, ViewChild } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Observable, Subject, debounceTime, distinctUntilChanged, switchMap } from 'rxjs';
import { Book } from 'src/app/shared/models/Book';
import { BookService } from 'src/app/shared/services/book/book.service';
import { SnackBarService } from 'src/app/shared/services/snackbar/snackbar.service';

@Component({
  selector: 'app-book-search',
  templateUrl: './book-search.component.html',
  styleUrl: './book-search.component.css'
})
export class BookSearchComponent implements OnInit{

  stars: number[] = [1, 2, 3, 4, 5]
  selectedStar!: number;
  formGroup!: UntypedFormGroup;

  displayedColumns: string[] = ['title', 'author', 'publisher'];
  results : Book[] = [];
  dataSource = new MatTableDataSource(this.results);

  request = {
    Title: '',
    Author: '',
    Publisher: ''
  };
  searchBook = new Subject<Object>();
  searchFields$!: Observable<Book[]>;

  constructor(private _fb: UntypedFormBuilder, private bookService: BookService, private snackBarService: SnackBarService, private router: Router) {
    
  }

  @ViewChild(MatSort) sort!: MatSort;
  
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {

    this.searchFields$ = this.searchBook.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap((book) => this.bookService.bookSearch(book)),
    );

    this.formGroup = this._fb.group({
      title: [],
      author: [],
      publisher: []
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  navigateBook(book: Book) {
    if(book.locked){
      this.snackBarService.openSnackBar("This book is currently locked and not available. Please try later.", "Ok");
    } else {
      this.router.navigate(['/book/' + book.bookId]);
    }
    
  }

  countStars(star: number){
    if(this.selectedStar == star)
      this.selectedStar = 0;
    else
      this.selectedStar = star;
  }

  searchTitle(value: string) {
    this.request.Title = value;
    this.search();
  }

  searchAuthor(value: string) {
    this.request.Author = value;
    this.search();
  }

  searchPublisher(value: string) {
    this.request.Publisher = value;
    this.search();
  }

  search() {
    this.searchBook.next(this.request);
    this.searchFields$.subscribe({
      next: (val) => {
        console.log(val);
        this.results = val;
        this.dataSource.data = this.results;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      }
    });
  }


}
