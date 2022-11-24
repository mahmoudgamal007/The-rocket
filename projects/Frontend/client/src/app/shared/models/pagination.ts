import { IProduct } from "./product";

export interface IPagination {
    products: IProduct[],
    productMatchCount: number,
    startIndex: number,
    endIndex: number,
    productPerPage: number
}