import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'
import { IProduct } from '../shared/models/product';
import { shopParams } from '../shared/models/shopParams';
import { map, delay } from 'rxjs/operators';
import { IPagination } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl: string = 'http://localhost:52437/Api/Product/';
  constructor(private http: HttpClient) { }


  getProducts(shopParams: shopParams) {
    let params = new HttpParams();

    if (shopParams.searchTerm && shopParams.searchTerm !== '') {
      params = params.append('SearchTerm', shopParams.searchTerm);
    }

    if (shopParams.minPrice && shopParams.minPrice !== 0) {
      params = params.append('MinPrice', shopParams.minPrice.toString());
    }

    if (shopParams.maxPrice && shopParams.maxPrice !== 0) {
      params = params.append('MaxPrice', shopParams.maxPrice.toString());
    }

    if (shopParams.name && shopParams.name !== '') {
      params = params.append('Name', shopParams.name);
    }

    if (shopParams.sellerId && shopParams.sellerId !== 0) {
      params = params.append('SellerId', shopParams.sellerId.toString());
    }

    if (shopParams.sortBy && shopParams.sortBy !== '') {
      params = params.append('SortBy', shopParams.sortBy);
    }

    if (shopParams.sortOrder && shopParams.sortBy !== '') {
      params = params.append('SortOrder', shopParams.sortOrder);
    }

    if (shopParams.pageNumber && shopParams.pageNumber !== 0) {
      params = params.append('Page', shopParams.pageNumber.toString());
    }

    if (shopParams.pageSize && shopParams.pageSize !== 0) {
      params = params.append('Size', shopParams.pageSize.toString());
    }


    return this.http.get<IPagination>(this.baseUrl + 'GetProducts', { observe: 'response', params })
      .pipe(
        map(response => { return response.body; })
      );
  }

}
