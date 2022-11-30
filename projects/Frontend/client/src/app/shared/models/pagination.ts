import { IProduct } from "./IProduct";

export interface IPagination {
    products: IProduct[],
    productMatchCount: number,
    startIndex: number,
    endIndex: number,
    productPerPage: number
}