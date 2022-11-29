import { HttpClient, HttpEventType } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Size } from '../shared/models/Size';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Color } from '../shared/models/Color';
import { IAppUser } from '../shared/models/IAppUser';
import { IProduct } from '../shared/models/product';
import { IUser } from '../shared/models/user';
import { SubCategory } from '../shared/models/subCategory';
import { ToastInjector } from 'ngx-toastr';

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
  getProducts(sellerId: any) {
    return this.http.get<IProduct[]>(
      this.baseUrl + 'Product/action?sellerId=' + sellerId.toString()
    );
  }

  getColors() {
    return this.http.get<Color[]>(
      this.baseUrl + 'Color'
    );
  }

  getSizes() {
    return this.http.get<Size[]>(
      this.baseUrl + 'Size'
    );
  }

  getSubCategory() {
    return this.http.get<SubCategory[]>(
      this.baseUrl + 'SubCategory'
    );
  }

postNewProduct(product:IProduct){
  console.log(product);

  return this.http.post(this.baseUrl+'Product',product);
}

  // uploadImage(files: any) {

  //   let fileToUpload = <File>files;
  //   const formData = new FormData();
  //   for (let i = 0; i < files.length; i++) {
  //     formData.append(files[i].name, files[i])
  //   }
  //   return this.http.post(this.baseUrl + 'Image', formData, { reportProgress: true, observe: 'events' });

  // }
}
