import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AccountService } from 'src/app/account/account.service';
import { IOrder } from 'src/app/shared/models/order';
import { buyerService } from '../buyer.service';



@Component({
  selector: 'app-buyer-orders',
  templateUrl: './buyer-orders.component.html',
  styleUrls: ['./buyer-orders.component.scss']
})
export class BuyerOrdersComponent implements OnInit {
  ds: any;
  orders: IOrder[] = [];
  buyerid!:any;

  constructor(private buyerService: buyerService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getOrders();
  }


  getOrders() {
    let id: number |undefined;
    
    this.buyerService.getCurrentBuyerAppUser().subscribe(response => {this.buyerid = response.buyer?.buyerId; 
    console.log(response.buyer?.buyerId)
    
    console.log(this.buyerid)
    this.buyerService.getAllOrdersByBuyerId(this.buyerid!).subscribe(response => {
      this.orders=response
    })
    })
  }

}
