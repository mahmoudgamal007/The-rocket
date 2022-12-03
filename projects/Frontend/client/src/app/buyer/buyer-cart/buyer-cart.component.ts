import { Component, OnInit } from '@angular/core';
import { ICart } from 'src/app/shared/models/ICart';
import { SharedService } from 'src/app/shared/shared.service';
import { buyerService } from '../buyer.service';

@Component({
  selector: 'app-buyer-cart',
  templateUrl: './buyer-cart.component.html',
  styleUrls: ['./buyer-cart.component.scss']
})
export class BuyerCartComponent implements OnInit {
  carts: ICart[] = [];


  constructor(private buyerService: buyerService, private sharedService: SharedService) { }

  ngOnInit(): void {
    this.LoadCurrentBuyerCarts();
  }

  LoadCurrentBuyerCarts() {
    this.sharedService.getCurrentAppUser().subscribe(res => {
      this.buyerService.getCurrentCartsByBuyerId(res.buyer?.buyerId!).subscribe(res => { this.carts = res }, err => { console.log(err) })
    }, err => { console.log(err) });


  }

}
