import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';
import { SessionService } from '../session/session.service';
import { HttpClient } from '@angular/common/http';
import { Book } from '../../models/Book';
import { BOOK_CONTROLLER } from '../../constants/server-constants';

@Injectable({
  providedIn: 'root'
})
export class BookService extends BaseService {

  constructor(sessionService: SessionService, 
              private http: HttpClient) {
    super(sessionService);
  }

  getBook(bookId: number) {
    console.log(`Calling ${BOOK_CONTROLLER + bookId}...`)
    return this.http.get<Book>(`${BOOK_CONTROLLER + bookId}`, {headers: this.buildHeaders()});
  }

  getBooks() {
    return this.http.get<Book>(`${BOOK_CONTROLLER}`, {headers: this.buildHeaders()});
  }

  saveBook(book: Book) {
    return this.http.post<Book>(`${BOOK_CONTROLLER}`, book, {headers: this.buildHeaders()});
  }

  updateBook(book: Book) {
    return this.http.put<Book>(`${BOOK_CONTROLLER}`, book, {headers: this.buildHeaders()});
  }

  deleteBook(bookId: number) {
    return this.http.delete(`${BOOK_CONTROLLER}${bookId}`, {headers: this.buildHeaders()});
  }

  uploadCover(formData: FormData){
    console.log(formData);
    return this.http.post(`${BOOK_CONTROLLER}uploadcover`, formData, {headers: this.buildMultipartHeaders()});
  }

  getRandomSampling(count: number) {
    return this.http.get<Book[]>(`${BOOK_CONTROLLER}getRandomSampling/${count}`, {headers: this.buildHeaders()});
  }

  bookSearch(request: any) {
    return this.http.post<Book[]>(`${BOOK_CONTROLLER}search/`, request, {headers: this.buildHeaders()});
  }

  lockBook(bookId: number){
    return this.http.get<boolean>(`${BOOK_CONTROLLER}lock/${bookId}`, {headers: this.buildHeaders()});
  }

  unlockBook(bookId: number){
    return this.http.get<boolean>(`${BOOK_CONTROLLER}unlock/${bookId}`, {headers: this.buildHeaders()});
  }

  checkout(bookId: number){
    return this.http.post<Book[]>(`${BOOK_CONTROLLER}checkout/${bookId}/${this.sessionService.getUserId()}`, null, {headers: this.buildHeaders()});
  }
}
