import { NgForOf } from '@angular/common';
import { Component, Injectable, OnInit } from '@angular/core';
import { filter } from 'rxjs/operators';
import { AccountService } from 'src/app/account/account.service';
import { IAppUser } from 'src/app/shared/models/IAppUser';
import { IOrder } from 'src/app/shared/models/IOrder';
import { IUser } from 'src/app/shared/models/user';
import { SellerService } from '../seller.service';

@Component({
  selector: 'app-seller-orders',
  templateUrl: './seller-orders.component.html',
  styleUrls: ['./seller-orders.component.scss']
})
@Injectable ()
export class SellerOrdersComponent implements OnInit {
  appUser!: IAppUser;
  currentUser!: IUser | null;
  id!: any;
  sellerId:any
  orders:any;
  users:any;
  buyer:any;
  constructor(
    private accountService: AccountService,
    private sellerService: SellerService
  ) {}

  ngOnInit(): void {
    this.accountService.currentUser$
      .pipe(filter((res) => res != null))
      .subscribe((res) => {
        this.id = res?.userId;
        this.getUser();
        
        
      });
  }


  getUser() {
    return this.sellerService.getUser(this.id).subscribe(
      (response) => {
        this.appUser = response;
        console.log(this.appUser.seller?.sellerId);
        this.sellerId=this.appUser.seller?.sellerId;
      this.sellerService.getAllOrders(this.sellerId).subscribe(
        (response)=>{
          
          this.orders=response;
          console.log(this.orders);
          this.sellerService.getAllusers().subscribe(
            (response) => {
           
              this.users=response;
              
               console.log(response)
              // this.getBuyerName(2);
             
             // console.log(this.users[0].buyer)
             ;}
          )
        }
      )
      },
      (error) => {
        console.log(error);
      }
    );
  }
  getBuyerName(buyerId:number)
  {
    this.users.forEach(function(Value:any)  {
      if (Value.buyer.buyerId!=null && Value.buyer.buyerId==buyerId)
      console.log(Value.buyer.firstName)
    });
  

  
  }

  getOrders(){
    this.getUser();
    return this.sellerService.getAllOrders(this.sellerId).subscribe(
      (response) => {
         
        console.log(response);
        
      },
      (error) => {
        console.log(error);
      }
    );
      }

      AcceptOrder(id:any,order:IOrder){
        console.log("click");
        order.deliveryStatus=1;
       this.sellerService.EditOrder(id,order).subscribe(res=>{
        console.log(res);

        })
      }
      
      CancelOrder(id:any,order:IOrder){
        console.log("click");
        order.deliveryStatus=4;
       this.sellerService.EditOrder(id,order).subscribe(res=>{
        console.log(res);

        })
      }
}
