import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map } from 'rxjs';
import { LIBRARIAN } from 'src/app/shared/constants/role-constants';
import { IMAGE_HOST_URL } from 'src/app/shared/constants/server-constants';
import { Book } from 'src/app/shared/models/Book';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { BookService } from 'src/app/shared/services/book/book.service';
import { SnackBarService } from 'src/app/shared/services/snackbar/snackbar.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrl: './book.component.css'
})
export class BookComponent implements OnInit{

  @Input() bookId!: number;
  book: Book = new Book();
  editMode: boolean = false;
  librarian = false;

  constructor(private bookService: BookService, private snackBarSerivce: SnackBarService, private activeRoute: ActivatedRoute, private router: Router, private authService: AuthService) {}

  ngOnInit(): void {
    this.authService.hasRole(LIBRARIAN)
      .subscribe({
        next: (val) => {
          this.librarian = val;  
        }
    });
    this.bookId = this.activeRoute.snapshot.params['bookId'];
    if(this.bookId != undefined && this.bookId > 0)
    {
      this.bookService.getBook(this.bookId).subscribe({
        next: (val) => {
          this.book = val;
        },
        error: (err) => {
          this.snackBarSerivce.openSnackBar(err.error, "close");
        }
       });
    }
  }

  checkout() {
    this.bookService.checkout(this.bookId).subscribe({
      next: (val) => {
        this.router.navigate(['home']);
        this.snackBarSerivce.openSnackBar("You have checked out the book, enjoy!", "Ok");
      },
      error: (err) => {
        this.snackBarSerivce.openSnackBar(err.error, "Ok")
      }
    })
  }

  checkIn(bookId: number) {
    if(this.book.currentStock == this.book.totalStock){
      this.snackBarSerivce.openSnackBar("This book is already at max stock.", "Ok");
    } else if(this.book.currentStock < this.book.totalStock) {
      this.book.currentStock++;
      this.bookService.updateBook(this.book).subscribe({
        next: (val) => {
          this.snackBarSerivce.openSnackBar("The book has been checked in.", "Ok");
        }
      })
    }

  }

  isInEditMode(){
    return this.editMode;
  }

  getImageUrl(){
    return IMAGE_HOST_URL + this.book.coverImage;
  }

  canBeCheckedOut(){
    return this.book.currentStock > 0;
  }

  navigateManage(bookId: number){
    this.router.navigate([`manage-book`, bookId]);
  }

  checkLibrarianRole(){
    return this.librarian;
  }

}
