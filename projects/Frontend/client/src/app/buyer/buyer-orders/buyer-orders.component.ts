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
  ds: any
  orders: IOrder[] = [];

  constructor(private buyerService: buyerService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getOrders();
  }


  getOrders() {
    let id: number | undefined;
    this.buyerService.getCurrentBuyerAppUser().subscribe(response => { id = response.buyer?.buyerId; })
    this.buyerService.getAllOrdersByBuyerId(id!).subscribe(response => {
      console.log(response)
      // if(res.order?.deliveryStatus==0){
      //   this.ds="Stock"
      // }
      // else if(res.order?.deliveryStatus==1){
      //   this.ds="Shipping"
      // }
      // else if(res.order?.deliveryStatus==2){
      //   this.ds="Delivvered"
      // }
    })
  }

}
