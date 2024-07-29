import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatSort, Sort } from '@angular/material/sort'
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Book } from 'src/app/shared/models/Book';
import { BookService } from 'src/app/shared/services/book/book.service';
import { SnackBarService } from 'src/app/shared/services/snackbar/snackbar.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit, AfterViewInit{
  
  displayedColumns: string[] = ['title', 'author', 'publisher', 'pagecount'];
  featuredBooks : Book[] = [];
  dataSource = new MatTableDataSource(this.featuredBooks);
  

  constructor(private bookService: BookService, private snackBarService: SnackBarService, private router: Router) {
    
  }

  @ViewChild(MatSort) sort!: MatSort;

  ngOnInit(): void {
    this.bookService.getRandomSampling(10).subscribe({
      next: val => {
        this.featuredBooks = val;
        this.dataSource.data = this.featuredBooks;
      },
      error: err => {
        this.snackBarService.openSnackBar(err.message, "Ok");
      }
    })
  }

  ngAfterViewInit(): void {
      this.dataSource.sort = this.sort;
  }

  navigateBook(book: Book) {
    this.router.navigate(['/book/' + book.bookId]);
  }


}
