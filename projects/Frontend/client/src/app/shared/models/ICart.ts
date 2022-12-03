import { IProduct } from "./IProduct";

export interface ICart {
    id: number;
    quantity: number;
    isSubmitted: boolean;
    productId: number;
    product: IProduct;
    buyerId: number;
}