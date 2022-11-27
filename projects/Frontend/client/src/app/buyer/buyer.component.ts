import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs';
import { AccountService } from '../account/account.service';
import { IAppUser } from '../shared/models/appUser';
import { IBuyer } from '../shared/models/buyer';
import { IUser } from '../shared/models/user';
import { buyerService } from './buyer.service';

@Component({
  selector: 'app-buyer',
  templateUrl: './buyer.component.html',
  styleUrls: ['./buyer.component.scss']
})
export class BuyerComponent implements OnInit {
  currentUser$!:Observable<IUser|null>;
  userId:string  ='' ;
  currentBuyer$!:Observable<IAppUser> ;

  constructor(private accountService:AccountService,private buyerService:buyerService ) { }

  ngOnInit(): void {
this.currentUser$ = this.accountService.currentUser$;
this.loadUser();
this.loadBuyer();

  }

  loadUser(){
    this.currentUser$.subscribe(response=>{this.userId= response!.userId;},error=>{console.log(error)});
  }

  loadBuyer(){
   this.currentBuyer$ = this.buyerService.getBuyerById(this.userId);
  }


 

}
