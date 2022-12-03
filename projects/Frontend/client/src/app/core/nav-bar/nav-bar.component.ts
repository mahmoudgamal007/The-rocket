import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { buyerService } from 'src/app/buyer/buyer.service';
import { ICart } from 'src/app/shared/models/ICart';
import { IUser } from 'src/app/shared/models/user';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  localStorage=localStorage;
  currentUser$!: Observable<IUser | null>;
  basket$!: Observable<ICart[] | null>;

  constructor(private accountService: AccountService, private ts: ToastrService, private buyerService: buyerService) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
    this.basket$ = this.buyerService.basket$;
  }

  logout() {
    this.accountService.logout();
    this.ts.success('Logged out successfully', 'Logged out');
  }
}
