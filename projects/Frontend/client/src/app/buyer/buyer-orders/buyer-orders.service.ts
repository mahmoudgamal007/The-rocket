import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class buyerOrderService {
  baseUrl= environment.apiUrl;
  constructor(private http: HttpClient) {
   }
  getAllOrders(){
    return this.http.get("http://localhost:52437/api/Order");
  }

}