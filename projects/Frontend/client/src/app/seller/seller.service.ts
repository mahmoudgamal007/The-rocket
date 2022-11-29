import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
<<<<<<< HEAD

@Injectable({
  providedIn: 'root'
})
export class SellerService {

  SERVER_URL: string = "https://file.io/";  
	constructor(private httpClient: HttpClient) { }

  public upload(formData:any) {

    return this.httpClient.post<any>(this.SERVER_URL, formData, {  
        reportProgress: true,  
        observe: 'events'  
      });  
=======
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IAppUser } from '../shared/models/IAppUser';
import { IProduct } from '../shared/models/product';
import { IUser } from '../shared/models/user';

@Injectable({
  providedIn: 'root',
})
export class SellerService {
  currentUser$!: Observable<IUser | null>;
  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}
  getUser(userId: any) {
    return this.http.get<IAppUser>(
      this.baseUrl + 'AppUser/GetAppUserByUserId?AppUserId=' + userId.toString()
    );
  }
  getProducts(sellerId: any) {
    return this.http.get<IProduct[]>(
      this.baseUrl + 'Product/action?sellerId=' + sellerId.toString()
    );
>>>>>>> refs/remotes/origin/newDeveloping
  }
}
