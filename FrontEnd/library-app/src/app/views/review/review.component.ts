import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Review, ReviewDTO } from 'src/app/shared/models/Review';
import { ReviewService } from 'src/app/shared/services/review/review.service';
import { SessionService } from 'src/app/shared/services/session/session.service';
import { SnackBarService } from 'src/app/shared/services/snackbar/snackbar.service';

@Component({
  selector: 'app-book-reviews',
  templateUrl: './review.component.html',
  styleUrl: './review.component.css'
})
export class ReviewComponent implements OnInit {

  @Input() bookId!: number;

  reviewIndex: number = 0;
  reviews: ReviewDTO[] = [];
  stars: number[] = [1, 2, 3, 4, 5]
  selectedStar!: number;
  formGroup!: UntypedFormGroup;

  displayedColumns: string[] = ['reviewer','review','rating'];
  dataSource = new MatTableDataSource(this.reviews);

  ngOnInit(): void {
    this.reviewService.getReviews(this.bookId)
      .subscribe({
        next: (val) =>{
          this.updateDataSource(val);
        }
    });
    this.formGroup = this._fb.group({
      review: [null, Validators.required],
    });
  }

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private reviewService: ReviewService, private snackBarSerivce: SnackBarService, private _fb: UntypedFormBuilder, private sessionSerivce: SessionService) {}

  countStars(star: number){
    if(this.selectedStar == star)
      this.selectedStar = 0;
    else
      this.selectedStar = star;
  }

  addReview(){
    if(this.selectedStar == 0){
      this.snackBarSerivce.openSnackBar("You must give a rating before submitting your review.", "Okay");
    } 
    else{
      let review: Review = new Review();
      review.reviewId = 0;
      review.bookId = this.bookId;
      review.libraryUserId = this.sessionSerivce.getUserId()!;
      review.rating = this.selectedStar;
      review.reviewText = this.formGroup.controls['review'].value;
      this.reviewService.addReview(review).subscribe({
        next: (val) => {
          this.reviewService.getReviews(review.bookId)
          .subscribe({
            next: (val) =>{
              this.updateDataSource(val);
              this.formGroup.reset();
              this.selectedStar = 0;
            }
          });
        },
        error: (err) => {
          console.log(err);
          this.snackBarSerivce.openSnackBar("An error occured saving your review: " + err.error, "Ok");
        }
      });
    }
  }

  updateDataSource(val: ReviewDTO[]){
    this.reviews = val;
    this.dataSource.data = this.reviews;
    this.dataSource.paginator = this.paginator;
  }
}
