import { Component, OnInit } from '@angular/core';
import { filter } from 'rxjs/operators';
import { AccountService } from 'src/app/account/account.service';
import { IAppUser } from 'src/app/shared/models/IAppUser';
import { IOrder } from 'src/app/shared/models/IOrder';
import { IUser } from 'src/app/shared/models/user';
import { SellerService } from '../seller.service';

@Component({
  selector: 'app-seller-shipping',
  templateUrl: './seller-shipping.component.html',
  styleUrls: ['./seller-shipping.component.scss']
})
export class SellerShippingComponent implements OnInit {

  appUser!: IAppUser;
  currentUser!: IUser | null;
  id!: any;


  sellerId: any
  orders: any;
  constructor(
    private accountService: AccountService,
    private sellerService: SellerService
  ) { }

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
        this.sellerId = this.appUser.seller?.sellerId;
        this.sellerService.getAllOrders(this.sellerId).subscribe(
          (response) => {

            this.orders = response;
            console.log(this.orders);
          }
        )
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getOrders() {
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

      DeliveredOrder(id:any,order:IOrder){
        console.log("click");
        order.deliveryStatus=2;
        order.deliveryDate= new Date ();
       this.sellerService.EditOrder(id,order).subscribe(res=>{
        console.log(res);

    })
  }

}
