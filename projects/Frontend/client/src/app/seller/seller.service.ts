import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IAppUser } from '../shared/models/appUser';
import { IProduct } from '../shared/models/product';
import { IUser } from '../shared/models/user';

@Injectable({
  providedIn: 'root'
})
export class SellerService {
  currentUser$!:Observable<IUser|null>;
  baseUrl: string = environment.apiUrl ;

  constructor(private http: HttpClient) {}
  getUser(userId:any)
  {
    return this.http.get<IAppUser>(this.baseUrl+'/AppUser/GetAppUserByUserId?AppUserId='+userId.toString())
  }
  getProducts()
  {
    return this.http.get<IProduct[]>(this.baseUrl+'Product/action?sellerId=6')
  }
 

  
}
