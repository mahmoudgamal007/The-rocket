import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'
import { IProduct } from '../shared/models/IProduct';
import { shopParams } from '../shared/models/shopParams';
import { map } from 'rxjs/operators';
import { IPagination } from '../shared/models/pagination';
import { environment } from 'src/environments/environment';
import { IFeedBack } from '../shared/models/IFeedBack';
import { Feedback } from '../shared/models/feedback';
import { IAppUser } from '../shared/models/IAppUser';

@Injectable({
  providedIn: 'root'
})

export class ProductService {
  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {
  }


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

    if (shopParams.sortOrder && shopParams.sortOrder !== '') {
      params = params.append('SortOrder', shopParams.sortOrder);
    }

    if (shopParams.mainCategory && shopParams.mainCategory !== '') {
      params = params.append('MainCategory', shopParams.mainCategory);
    }

    if (shopParams.subCategory && shopParams.subCategory !== '') {
      params = params.append('SubCategory', shopParams.subCategory);
    }


    params = params.append('SortBy', shopParams.sortBy);
    params = params.append('Page', shopParams.pageNumber.toString());
    params = params.append('Size', shopParams.pageSize.toString());




    return this.http.get<IPagination>(this.baseUrl + 'Product/GetProducts', { observe: 'response', params })
      .pipe(
        map(response => { return response.body; })
      );
  }

  getProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl + 'Product/GetProdcutById?id=' + id.toString())
  }

  getFeedbacks(productId: number) {
    return this.http.get<IFeedBack[]>(this.baseUrl + 'Feedbacks/GetAllFeedbacsByProductId?productId=' + productId.toString())
  }

  postFeedback(feedback: Feedback) {


    return this.http.post(this.baseUrl + 'Feedbacks', feedback);
  }

  getCurrentBuyer() {
    let guid = localStorage.getItem('userId');
    return this.http.get<IAppUser>(this.baseUrl + 'appuser/getappuserbyuserid?AppUserId=' + guid)
  }

}
