import { Book } from "./Book";
import { LibraryUser } from "./LibraryUser";

export interface IUserCheckout{
    userCheckoutId: number;
    bookId: number;
    libraryUserId: number;
    dateCheckedOut: string;
    book: Book;
    libraryUser: LibraryUser;
}

export class UserCheckout implements IUserCheckout{
    userCheckoutId!: number;
    bookId!: number;
    libraryUserId!: number;
    dateCheckedOut!: string;
    book!: Book;
    libraryUser!: LibraryUser;
}