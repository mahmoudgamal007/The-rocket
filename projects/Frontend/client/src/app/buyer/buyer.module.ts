import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BuyerComponent } from './buyer.component';
import { BuyerRoutingModule } from './buyer-routing.module';
import { BuyerCartComponent } from './buyer-cart/buyer-cart.component';
import { BuyerOrdersComponent } from './buyer-orders/buyer-orders.component';
import { SharedModule } from '../shared/shared.module';
import { CartItemComponent } from './cart-item/cart-item.component';
import { CartCheckoutComponent } from './cart-checkout/cart-checkout.component';




@NgModule({
  declarations: [
    BuyerComponent,
    BuyerCartComponent,
    BuyerOrdersComponent,
    CartItemComponent,
    CartCheckoutComponent,

  ],
  imports: [
    CommonModule,
    BuyerRoutingModule,
    SharedModule,
  ]
})
export class BuyerModule { }
