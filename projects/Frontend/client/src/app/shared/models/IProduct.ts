import { IImage } from "./img";

export interface IProduct {
    id: number;
    name: string;
    desctiption: string;
    quantity: number;
    price: number;
    discount: number;
    brand: string;
    subCategoryId: number;
    sellerId: number;
    colors: string[];
    sizes: string[];
    imgs: IImage[];
}
