import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { shopParams } from '../shared/models/shopParams';
import { map, delay } from 'rxjs/operators';
import { IPagination } from '../shared/models/pagination';
import { environment } from 'src/environments/environment';
import { IAppUser } from '../shared/models/appUser';
import { idLocale } from 'ngx-bootstrap';
import { __values } from 'tslib';
import { ThrowStmt } from '@angular/compiler';


@Injectable({
  providedIn: 'root'
})
export class buyerService {
  baseUrl= environment.apiUrl;
  constructor(private http: HttpClient) {
   }

// getBuyerById(userId?:string){
//   return this.http.get<IAppUser>(this.baseUrl+"AppUser/GetAppUserByUserId?AppUserId?="+userId);
// }
getBuyerById(id:any){
  return this.http.get<IAppUser>(this.baseUrl+"AppUser/GetAppUserByUserId?AppUserId="+id);
}
editbuyer(id:any,buyer:any={}){
  return this.http.put(this.baseUrl+"AppUser?Id="+id+"/"+buyer,__values);
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

}