import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SellerComponent } from './seller.component';
import { SellerOrdersComponent } from './seller-orders/seller-orders.component';


const routes: Routes = [
  { path: '', component: SellerComponent },
  { path: 'orders', component: SellerOrdersComponent },

]
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule]
})
export class SellerRoutingModule { }
