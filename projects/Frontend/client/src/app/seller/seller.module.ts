import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SellerComponent } from './seller.component';
import { SellerRoutingModule } from './seller-routing.module';
import { SharedModule } from '../shared/shared.module';

import { SellerOrdersComponent } from './seller-orders/seller-orders.component';
import { SellerReturnsComponent } from './seller-returns/seller-returns.component';
import { SellerHistoryComponent } from './seller-history/seller-history.component';
import { SellerShippingComponent } from './seller-shipping/seller-shipping.component';
import { AddProductComponent } from './add-product/add-product.component';




@NgModule({
  declarations: [
    SellerComponent,
    SellerOrdersComponent,
    SellerReturnsComponent,
    SellerHistoryComponent,
    SellerShippingComponent,
    AddProductComponent
    
  ],
  imports: [
    CommonModule,
    SellerRoutingModule,
    SharedModule
  ],
  exports: [SellerComponent]
})
export class SellerModule { }
