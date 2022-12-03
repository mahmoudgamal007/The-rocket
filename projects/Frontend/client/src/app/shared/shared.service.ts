import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IAppUser } from './models/IAppUser';

@Injectable({
  providedIn: 'root'
})
export class SharedService {


  constructor(private http: HttpClient) { }
  baseUrl: string = environment.apiUrl;
  uploadImage(files: any) {

    let fileToUpload = <File>files;
    const formData = new FormData();
    for (let i = 0; i < files.length; i++) {
      formData.append(files[i].name, files[i])
    }
    return this.http.post(this.baseUrl + 'Image', formData, { reportProgress: true, observe: 'events' });

  }


  getAppUeserByUsrId(userId: any) {
    return this.http.get<IAppUser>(this.baseUrl + 'AppUser/GetAppUserByUserId?AppUserId=' + userId);
  }

  getCurrentAppUser() {
    return this.http.get<IAppUser>(this.baseUrl + 'AppUser/GetAppUserByUserId?AppUserId=' + localStorage.getItem('userId'));
  }


}