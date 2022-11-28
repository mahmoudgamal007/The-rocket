import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { buyerOrderService } from './buyer-orders.service';


@Component({
  selector: 'app-buyer-orders',
  templateUrl: './buyer-orders.component.html',
  styleUrls: ['./buyer-orders.component.scss']
})
export class BuyerOrdersComponent implements OnInit {
  ds:any
  orders:any[]=[]

  constructor(private  orderService:buyerOrderService,private route:ActivatedRoute ) { }

  ngOnInit(): void {
    this.getOrders();
  }
  getOrders(){
    this.orderService.getAllOrders().subscribe((res:any)=>{
      this.orders=res
      // if(res.order?.deliveryStatus==0){
      //   this.ds="Stock"
      // }
      // else if(res.order?.deliveryStatus==1){
      //   this.ds="Shipping"
      // }
      // else if(res.order?.deliveryStatus==2){
      //   this.ds="Delivvered"
      // }

console.log(res);
    })
  }

}
