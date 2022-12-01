import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SellerComponent } from './seller.component';
import { SellerOrdersComponent } from './seller-orders/seller-orders.component';
import { SellerHistoryComponent } from './seller-history/seller-history.component';
import { SellerShippingComponent } from './seller-shipping/seller-shipping.component';
import { SellerReturnsComponent } from './seller-returns/seller-returns.component';
import { AddProductComponent } from './add-product/add-product.component';
import { SellerAuthGuard } from '../core/guards/seller-auth.guard';


const routes: Routes = [
  { path: '', canActivate: [SellerAuthGuard], component: SellerComponent },
  { path: 'orders', canActivate: [SellerAuthGuard], component: SellerOrdersComponent },
  { path: 'returns', canActivate: [SellerAuthGuard], component: SellerReturnsComponent },
  { path: 'history', canActivate: [SellerAuthGuard], component: SellerHistoryComponent },
  { path: 'shipping', canActivate: [SellerAuthGuard], component: SellerShippingComponent },
  { path: 'addProduct', canActivate: [SellerAuthGuard], component: AddProductComponent }


]
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class SellerRoutingModule { }