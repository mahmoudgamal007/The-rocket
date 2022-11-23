import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'
import { IProduct } from '../shared/models/product';
import { shopParams } from '../shared/models/shopParams';
import { map, delay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl: string = 'http://localhost:52437/Api/Product/';
  constructor(private http: HttpClient) { }


  getProducts(shopParams: shopParams) {
    let params = new HttpParams();

    if (shopParams.searchTerm && shopParams !== '') {
      params = params.append('SearchTerm', shopParams.searchTerm);
    }

    return this.http.get<IProduct[]>(this.baseUrl + 'GetProducts', { observe: 'response', params })
      .pipe(
        map(response => { return response.body; })
      );
  }



}
