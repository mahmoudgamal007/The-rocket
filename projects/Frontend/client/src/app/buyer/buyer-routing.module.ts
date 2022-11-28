import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { BuyerComponent } from './buyer.component';
import { BuyerCartComponent } from './buyer-cart/buyer-cart.component';
import { BuyerOrdersComponent } from './buyer-orders/buyer-orders.component';


const routes: Routes = [
  { path: 'profile/:id', component: BuyerComponent },
  { path: 'cart', component: BuyerCartComponent },
  { path: 'order', component: BuyerOrdersComponent },

  
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
