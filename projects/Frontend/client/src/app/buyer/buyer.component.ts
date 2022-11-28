import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { Observable } from 'rxjs';
import { AccountService } from '../account/account.service';
import { IAppUser } from '../shared/models/IAppUser';
import { IBuyer } from '../shared/models/Ibuyer';
import { IUser } from '../shared/models/user';
import { buyerService } from './buyer.service';

@Component({
  selector: 'app-buyer',
  templateUrl: './buyer.component.html',
  styleUrls: ['./buyer.component.scss']
})
export class BuyerComponent implements OnInit {
  currentUser$!: Observable<IUser | null>;
  currentBuyer!: IAppUser | null;

  




  constructor(private accountService: AccountService, private buyerService: buyerService,private fb:FormBuilder) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
    this.buyerService.getCurrentBuyer().subscribe(response => { this.currentBuyer = response }, error => { console.log(error) })
  }











}
