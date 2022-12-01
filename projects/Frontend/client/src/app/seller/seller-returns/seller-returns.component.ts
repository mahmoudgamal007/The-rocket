import { Component, OnInit } from '@angular/core';
import { filter } from 'rxjs/operators';
import { AccountService } from 'src/app/account/account.service';
import { IAppUser } from 'src/app/shared/models/IAppUser';
import { IOrder } from 'src/app/shared/models/IOrder';
import { IUser } from 'src/app/shared/models/user';
import { SellerService } from '../seller.service';

@Component({
  selector: 'app-seller-returns',
  templateUrl: './seller-returns.component.html',
  styleUrls: ['./seller-returns.component.scss']
})
export class SellerReturnsComponent  {
  appUser!: IAppUser;
  currentUser!: IUser | null;
  id!: any;
 sellerId:any
  orders:any;
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
        }
      )
      },
      (error) => {
        console.log(error);
      }
    );
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
      AcceptReturnRequest(id:any,order:IOrder){
        console.log("click");
        order.deliveryStatus=1;
        order.isReturned=true;
        order.returnRequest=false;
       this.sellerService.EditOrder(id,order).subscribe(res=>{
        console.log(res);

        })
      }
      CancelReturnRequest(id:any,order:IOrder){
        console.log("click");
        order.deliveryStatus=4;
       this.sellerService.EditOrder(id,order).subscribe(res=>{
        console.log(res);

        })
      }      

}