import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ICart } from '../shared/models/cart';
@Injectable({
  providedIn: 'root'
})
export class CartService {
  baseUrl=environment.apiUrl;

  constructor(private http:HttpClient) { }
  getCarts(buyerId:number)
  {
    return this.http.get<ICart[]>(this.baseUrl+'ReserveCart/GetCartsByBuyerId?BuyerId='+buyerId.toString())
    
  }
}
