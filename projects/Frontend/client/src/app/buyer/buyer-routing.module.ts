import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { BuyerComponent } from './buyer.component';
import { BuyerCartComponent } from './buyer-cart/buyer-cart.component';
import { BuyerOrdersComponent } from './buyer-orders/buyer-orders.component';
import { OrderDetailsComponent } from './order-details/order-details.component';

const routes: Routes = [
  { path: 'profile/:id', component: BuyerComponent },
  { path: 'cart', component: BuyerCartComponent },
  { path: 'order', component: BuyerOrdersComponent },
  { path: 'order/:id', component: OrderDetailsComponent },

]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class BuyerRoutingModule { }
