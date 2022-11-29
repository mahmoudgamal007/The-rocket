import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SellerComponent } from './seller.component';
import { SellerOrdersComponent } from './seller-orders/seller-orders.component';
import { SellerRoutingModule } from './seller-routing.module';
import { AddProductComponent } from './add-product/add-product.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';




@NgModule({
  declarations: [
    SellerComponent,
    SellerOrdersComponent,
    AddProductComponent
  ],
  imports: [
    CommonModule,
    SellerRoutingModule,
    FormsModule,
    SharedModule
  ]
})
export class SellerModule { }
