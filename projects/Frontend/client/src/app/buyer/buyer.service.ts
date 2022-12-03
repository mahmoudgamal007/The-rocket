import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IAppUser } from '../shared/models/IAppUser';
import { IOrder } from '../shared/models/IOrder';
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

  editbuyer(id: any, buyer: any) {
    console.log(buyer)
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
  editAddressbuyer(id: number, address: any) {
    id = address.id;
    return this.http.put("http://localhost:52437/Api/Address?id=" + id, address);

  }
  addAddressbuyer(address: any) {
    return this.http.post("http://localhost:52437/Api/Address", address);
  }
  deleteAddressbuyer(id: number) {
    return this.http.delete("http://localhost:52437/Api/Address?id=" + id);
  }
  editPhonebuyer(id: number, phone: any) {
    id = phone.id;
    return this.http.put("http://localhost:52437/Api/Phone?id=" + id, phone);
  }
  addPhonebuyer(phone: any) {
    console.log(phone)
    return this.http.post("http://localhost:52437/Api/Phone", phone);
  }
  deletePhonebuyer(id: number) {
    return this.http.delete("http://localhost:52437/Api/Phone?id=" + id);
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
    return this.http.post(this.baseUrl + 'Order', order);
  }


}