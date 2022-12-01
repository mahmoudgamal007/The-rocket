import { Color } from "./Color";
import { Image } from "./Image";
import { Size } from "./Size";

export class Product {
 
    id?: number;
    name?: string;
    desctiption?: string;
    quantity?: number;
    price?: number;
    discount?: number;
    brand?: string;
    subCategoryId?: number;
    sellerId?: number;
    ColorIds?: number[];
    SizeIds?: number[];
    ImgUrls?: string[];
}
