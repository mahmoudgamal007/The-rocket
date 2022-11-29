import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs';
import { AccountService } from '../account/account.service';
import { IUser } from '../shared/models/user';
import { buyerService } from './buyer.service';

@Component({
  selector: 'app-buyer',
  templateUrl: './buyer.component.html',
  styleUrls: ['./buyer.component.scss']
})
export class BuyerComponent implements OnInit {
  currentUser$!: Observable<IUser | null>;




  constructor(private accountService: AccountService, private buyerService: buyerService) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
  }


}
