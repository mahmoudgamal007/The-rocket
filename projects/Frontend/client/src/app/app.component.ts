import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { buyerService } from './buyer/buyer.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {

  constructor(private accountService: AccountService, private buyerService: buyerService) { }

  ngOnInit(): void {
    this.loadCurrentUser();
    this.LoadCurrentUserBasket();
  }
  title = 'Rocket';

  loadCurrentUser() {
    const token = localStorage.getItem('token');
    if (token) {
      this.accountService.loadCurrentUser(token)!.subscribe(
        (response) => {
          console.log(response);
        },
        (error) => {
          console.log(error);
        }
      );
    } else { this.accountService.setCurrentUserToNull(); }
  }

  LoadCurrentUserBasket() {
    const accType = localStorage.getItem('accountType');
    if (accType === 'Buyer') {
      this.buyerService.getCurrentBuyer().subscribe(res => {
        this.buyerService.getBasket(res.buyer?.buyerId!)
      }, error => { console.log(error) })

    }

  }


}
