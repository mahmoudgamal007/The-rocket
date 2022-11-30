import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IAppUser } from '../shared/models/IAppUser';
import { IUser } from '../shared/models/user';
import { shopParams } from '../shared/models/shopParams';
import { map, delay } from 'rxjs/operators';
import { IPagination } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root',
})
export class SellerService {
  currentUser$!: Observable<IUser | null>;
  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }
  getUser(userId: any) {
    return this.http.get<IAppUser>(
      this.baseUrl + 'AppUser/GetAppUserByUserId?AppUserId=' + userId.toString()
    );
  }
  getProducts(shopParams: shopParams) {
    let params = new HttpParams();

    if (shopParams.sellerId && shopParams.sellerId !== 0) {
      params = params.append('SellerId', shopParams.sellerId.toString());
    }

    return this.http
      .get<IPagination>(this.baseUrl + 'product/GetProducts', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          return response.body;
        })
      );
  }

  getAllOrders(sellerId:any){
    return this.http.get(this.baseUrl + 'Order/GetBySellerId?SellerId='+sellerId);
  }

  EditOrder(id:any,order:any={}){

    return this.http.put(this.baseUrl+"Order?Id="+id,order);
  }
}
