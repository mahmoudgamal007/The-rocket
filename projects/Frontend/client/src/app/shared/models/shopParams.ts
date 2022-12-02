export class shopParams {
    searchTerm?: string;
    pageNumber: number = 1;
    minPrice?: number;
    maxPrice?: number;
    name?: string;
    sellerId?: number;
    pageSize: number = 15;
    sortBy: string = 'Name';
    sortOrder!: string;
    mainCategory!: string;
    subCategory!: string;

}
