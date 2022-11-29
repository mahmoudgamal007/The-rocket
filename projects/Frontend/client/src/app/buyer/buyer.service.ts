import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AccountService } from '../account/account.service';


@Injectable({
  providedIn: 'root'
})
export class buyerService {

  

  constructor(private http: HttpClient, private accountService: AccountService) {
  }





}