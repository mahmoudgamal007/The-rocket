import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { shopParams } from '../shared/models/shopParams';
import { map, delay } from 'rxjs/operators';
import { IPagination } from '../shared/models/pagination';
import { environment } from 'src/environments/environment';
import { idLocale } from 'ngx-bootstrap';
import { __values } from 'tslib';
import { ThrowStmt } from '@angular/compiler';
import { IAppUser } from '../shared/models/IAppUser';
import { IOrder } from '../shared/models/order';
import { Buyer } from '../shared/models/buyer';


@Injectable({
  providedIn: 'root'
})
export class buyerService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {
  }

  // getBuyerById(userId?:string){
  //   return this.http.get<IAppUser>(this.baseUrl+"AppUser/GetAppUserByUserId?AppUserId?="+userId);
  // }
  getCurrentBuyer() {
    let id = localStorage.getItem('userId');
    return this.http.get<IAppUser>(this.baseUrl + "AppUser/GetAppUserByUserId?AppUserId=" + id);
  }

  editbuyer(id: any, buyer: any = {}) {
    return this.http.put(this.baseUrl + "AppUser?Id=" + id, buyer);
  }
  getbuyers(shopParams: shopParams) {
    let params = new HttpParams();

    if (shopParams.name && shopParams.name !== '') {
      params = params.append('Name', shopParams.name);
    }
    return this.http.get<IPagination>(this.baseUrl + 'getbuyers', { observe: 'response', params })
      .pipe(
        map(response => { return response.body; })
      );
  }

  getAllOrdersByBuyerId(BuyerId: number) {
    console.log(BuyerId + "asdasdasdsa")
    let id = BuyerId.toString();
    return this.http.get<IOrder[]>("http://localhost:52437/api/Order/GetByBuyerId?BuyerId=" + id);
  }

  getCurrentBuyerAppUser() {
    let id = localStorage.getItem('userId');
    return this.http.get<IAppUser>(this.baseUrl + 'AppUser/GetAppUserByUserId?AppUserId=' + id);
  }
}