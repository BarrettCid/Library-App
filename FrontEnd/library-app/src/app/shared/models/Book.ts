import { Review } from "./Review";
import { UserCheckout } from "./UserCheckout";

export interface IBook {
    bookId: number;
    title: string;
    author: string;
    description: string;
    coverImage: string;
    publisher: string;
    isbn: string;
    pageCount: number;
    locked: boolean;
    totalStock: number;
    currentStock: number;
    reviews: Review[];
    userCheckouts: UserCheckout[];
}

export class Book implements IBook{
    bookId!: number;
    title!: string;
    author!: string;
    description!: string;
    coverImage!: string;
    publisher!: string;
    isbn!: string;
    pageCount!: number;
    reviews!: Review[];
    locked!: boolean;
    totalStock!: number;
    currentStock!: number;
    userCheckouts!: UserCheckout[];
}
