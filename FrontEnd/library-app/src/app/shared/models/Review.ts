import { Book } from "./Book";
import { LibraryUser } from "./LibraryUser";

export interface IReview {
    reviewId: number;
    bookId: number;
    reviewText: string;
    libraryUserId: string;
    rating: number;
    book: Book;
    libraryUser: LibraryUser;
}

export class Review implements IReview {
    reviewId!: number;
    bookId!: number;
    reviewText!: string;
    libraryUserId!: string;
    rating!: number;
    book!: Book;
    libraryUser!: LibraryUser;
}

export class ReviewDTO {
    reviewer!: string;
    reviewText!: string;
    rating!: number;
}