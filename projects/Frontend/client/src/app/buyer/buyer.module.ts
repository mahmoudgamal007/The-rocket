import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BuyerComponent } from './buyer.component';
import { BuyerRoutingModule } from './buyer-routing.module';
import { BuyerCartComponent } from './buyer-cart/buyer-cart.component';
import { BuyerOrdersComponent } from './buyer-orders/buyer-orders.component';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { AccountService } from '../account/account.service';



@NgModule({
  declarations: [
    BuyerComponent,
    BuyerCartComponent,
    BuyerOrdersComponent,
    OrderDetailsComponent
  ],
  imports: [
    CommonModule,
    BuyerRoutingModule
  ], exports: []

})
export class BuyerModule { }
