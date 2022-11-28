import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SellerComponent } from './seller.component';
import { SellerOrdersComponent } from './seller-orders/seller-orders.component';
import { SellerRoutingModule } from './seller-routing.module';



@NgModule({
  declarations: [
    SellerComponent,
    SellerOrdersComponent
  ],
  imports: [
    CommonModule,
    SellerRoutingModule
  ]
})
export class SellerModule { }
