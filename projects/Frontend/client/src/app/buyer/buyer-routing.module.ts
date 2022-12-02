import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { BuyerComponent } from './buyer.component';
import { BuyerCartComponent } from './buyer-cart/buyer-cart.component';
import { BuyerOrdersComponent } from './buyer-orders/buyer-orders.component';
import { BuyerAuthGuard } from '../core/guards/buyer-auth.guard';


const routes: Routes = [
  { path: '', canActivate: [BuyerAuthGuard], component: BuyerComponent },
  { path: 'cart', canActivate: [BuyerAuthGuard], component: BuyerCartComponent },
  { path: 'order', canActivate: [BuyerAuthGuard], component: BuyerOrdersComponent },


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
