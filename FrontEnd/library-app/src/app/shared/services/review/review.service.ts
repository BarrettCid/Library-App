import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';
import { SessionService } from '../session/session.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Review, ReviewDTO } from '../../models/Review';
import { GET_REVIEWS, REVIEW_CONTROLLER } from '../../constants/server-constants';

@Injectable({
  providedIn: 'root'
})
export class ReviewService extends BaseService {

  constructor(sessionService: SessionService, 
      private http: HttpClient) { 
        super(sessionService)
      }

      addReview(review: Review) {
        return this.http.post<Review>(`${REVIEW_CONTROLLER}`, review, {headers: this.buildHeaders()});
      }

      getReviews(bookId: number) {
        return this.http.get<ReviewDTO[]>(`${GET_REVIEWS}${bookId}`, {headers: this.buildHeaders()});
      }

      pageReviewsByBook(bookId: number, reviewIndex: number) {
        return this.http.get<Review[]>(`${REVIEW_CONTROLLER + bookId}/${reviewIndex}`, {headers: this.buildHeaders()});
      }
}

