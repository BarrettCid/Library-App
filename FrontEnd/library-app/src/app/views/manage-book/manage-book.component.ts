import { AfterViewInit, Component, ContentChild, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IMAGE_HOST_URL } from 'src/app/shared/constants/server-constants';
import { Book } from 'src/app/shared/models/Book';
import { BookService } from 'src/app/shared/services/book/book.service';
import { SnackBarService } from 'src/app/shared/services/snackbar/snackbar.service';

@Component({
  selector: 'app-manage-book',
  templateUrl: './manage-book.component.html',
  styleUrl: './manage-book.component.css'
})
export class ManageBookComponent implements OnInit, AfterViewInit {

  @Input() bookId!: number;
  book!: Book;
  formGroup!: UntypedFormGroup;
  coverImageName!: string;
  @ViewChild('imgCover', { read: ElementRef }) coverDisplay!: ElementRef;
  @ViewChild('file', {read: ElementRef}) fileElement!: ElementRef;

  isEditMode(){
    return this.bookId > 0 ? true : false;
  }

  constructor(private bookService: BookService, private router: Router, private snackBarService: SnackBarService, private _fb: UntypedFormBuilder, private activeRoute: ActivatedRoute) {}

  ngOnInit(): void {
    console.log("in ngOn...");
    this.bookId = this.activeRoute.snapshot.params['bookId'];    

    this.formGroup = this._fb.group({
      title: [null, Validators.required],
      author: [null, Validators.required],
      description: [null, Validators.required],
      publisher: [null, Validators.required],
      isbn: [null, Validators.required]
    });

    if(this.bookId > 0) {
      this.bookService.lockBook(this.bookId).subscribe({
        next: (val) => {
          if(val) {
            this.bookService.getBook(this.bookId).subscribe({
              next: (val) => {
                this.book = val;
                this.patchForm(val);
              },
              error: (val) => {
                this.snackBarService.openSnackBar("An error occured loading the books data. Unlocking the book till issue is resolved.", "Ok");
                this.bookService.unlockBook(this.bookId).subscribe();
              }
            })
          }
        },
        error: (err) => {
          this.snackBarService.openSnackBar(err.error, "Ok");
        }
      });
    }
  }

  ngAfterViewInit() {

  }

  patchForm(book: Book)
  {
    this.formGroup.patchValue({author: book.author});
    this.formGroup.patchValue({title: book.title});
    this.formGroup.patchValue({description: book.description});
    this.formGroup.patchValue({publisher: book.publisher});
    this.formGroup.patchValue({isbn: book.isbn});

    this.coverDisplay.nativeElement.src = IMAGE_HOST_URL + this.book.coverImage;
    this.coverDisplay.nativeElement.width = 150;    
    this.coverDisplay.nativeElement.height = 200;
  }

  updateImage() {
    //we have a new image from the user
    if(this.fileElement.nativeElement.files.length > 0) {
      var currFile;
      var reader = new FileReader();
      reader.onload = () => {
        this.coverDisplay.nativeElement.src = reader.result;
        this.coverDisplay.nativeElement.width = 150;
        this.coverDisplay.nativeElement.height = 200;
      };
      this.coverImageName = this.fileElement.nativeElement.files[0].name;
      reader.readAsDataURL(this.fileElement.nativeElement.files[0]);
    }
  }

  saveBook() {
    if(this.fileElement.nativeElement.files.length == 0) {
      this.snackBarService.openSnackBar("You must select a file for the cover before saving.", "Ok");
    }
    if(this.bookId > 0) {
      this.getFormData();
      this.bookService.updateBook(this.book).subscribe({
        next: (val) => {
          console.log("update finished...");
          this.uploadCoverImage();
          if(this.fileElement.nativeElement.files.length == 0) {
            this.snackBarService.openSnackBar("Book saved!","Ok");
          }
          this.bookService.unlockBook(this.bookId).subscribe({
            next: (val) => {
              this.snackBarService.openSnackBar("Book updated!", "Ok");
              this.router.navigate(["book-search"]);
            }
          });
        },
        error: (err) => {
          this.snackBarService.openSnackBar(err.error, "Ok")
        }
      });
    } else {
      this.book = new Book();
      this.getFormData();
      this.bookService.saveBook(this.book).subscribe({
        next: (val) => {
          this.uploadCoverImage();
        },
        error: (err) => {
          this.snackBarService.openSnackBar(err.error, "Ok")
        }
      });
    }
  }

  getFormData() {
    this.book.author = this.formGroup.controls['author'].value;
    this.book.title = this.formGroup.controls['title'].value;
    this.book.description = this.formGroup.controls['description'].value;
    this.book.isbn = this.formGroup.controls['isbn'].value;
    this.book.totalStock = 1;
    this.book.currentStock = 1;
    if(this.fileElement.nativeElement.files.length > 0) {
      this.book.coverImage = this.coverImageName;
    }
  }

  uploadCoverImage() {
    console.log("in cover upload");
    if(this.fileElement.nativeElement.files.length > 0) {
      console.log("there is a cover to load...")
      var formData = new FormData();
      var file: File = this.fileElement.nativeElement.files[0];
      formData.append("file", file, file.name);
      formData.append("bookId", this.bookId.toString())
      formData.forEach(x => {
        console.log(x.valueOf())
      });
      this.bookService.uploadCover(formData).subscribe({
        next: (val) => {
          this.snackBarService.openSnackBar("Book saved and cover uploaded!","Ok");
          this.bookService.unlockBook(this.bookId).subscribe({
            next: (val) => {
              this.router.navigate(["book-search"]);
            }
          });
        }
      });
    }
  }

  deleteBook() {
    this.bookService.deleteBook(this.bookId).subscribe({
      next: () => {
        this.router.navigate(['book-search']);      
      },
    });
  }

  cancel() {
    this.bookService.unlockBook(this.bookId).subscribe({
      next: (val) => {
        if(this.bookId > 0)
        {
          this.router.navigate(['book-search']);
        } else {
          this.router.navigate(['home']);
        }
      }
    });
  }

}
