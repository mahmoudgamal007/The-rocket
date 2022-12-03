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
import { IOrder } from '../shared/models/IOrder';
import { Buyer } from '../shared/models/buyer';
import { FormControl } from '@angular/forms';
import { AppUser } from '../shared/models/appUser';
import { ICart } from '../shared/models/ICart';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { Order } from '../shared/models/order';


@Injectable({
  providedIn: 'root'
})
export class buyerService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<ICart[] | null>(null);
  basket$ = this.basketSource.asObservable();


  constructor(private http: HttpClient) {
  }
  getCurrentBuyer() {
    let id = localStorage.getItem('userId');
    return this.http.get<IAppUser>(this.baseUrl + "AppUser/GetAppUserByUserId?AppUserId=" + id);
  }

  editbuyer(id: any, buyer: AppUser) {
    id = localStorage.getItem('userId');
    return this.http.put("http://localhost:52437/Api/AppUser?Id=" + id, buyer);
  }
  getAllOrdersByBuyerId(BuyerId: number) {
    let id = BuyerId.toString();
    return this.http.get<IOrder[]>("http://localhost:52437/api/Order/GetByBuyerId?BuyerId=" + id);
  }
  getCurrentBuyerAppUser() {
    let id = localStorage.getItem('userId');
    return this.http.get<IAppUser>(this.baseUrl + 'AppUser/GetAppUserByUserId?AppUserId=' + id);
  }
  editAddressbuyer(id: any, address: any) {
    id = localStorage.getItem('userId');
    console.log(address);
    console.log(id)
    return this.http.put("http://localhost:52437/Api/Address?id=" + id, address);
  }

  requestRturnOrder(id: number) {
    return this.http.put(this.baseUrl + "Order/RequestReturn?OrderId=" + id, null);
  }

  getCurrentCartsByBuyerId(buyerId: number) {
    return this.http.get<ICart[]>(this.baseUrl + 'ReserveCart/GetCartsByBuyerId?BuyerId=' + buyerId.toString());
  }

  removeFromCart(id: number) {
    return this.http.delete(this.baseUrl + 'ReserveCart?id=' + id.toString())
  }

  getBasket(buyerId: number) {
    return this.http.get<ICart[]>(this.baseUrl + 'ReserveCart/GetCartsByBuyerId?BuyerId=' + buyerId.toString())
      .pipe(
        map((carts: ICart[]) => {
          this.basketSource.next(carts);
        }
        )
      );
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  postOrder(order: Order) {
    return this.http.post(this.baseUrl+'Order',order);
  }

 
}