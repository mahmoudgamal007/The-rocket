import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SellerComponent } from './seller.component';
import { SellerOrdersComponent } from './seller-orders/seller-orders.component';
import { SellerHistoryComponent } from './seller-history/seller-history.component';
import { SellerShippingComponent } from './seller-shipping/seller-shipping.component';
import { SellerReturnsComponent } from './seller-returns/seller-returns.component';
import { AddProductComponent } from './add-product/add-product.component';


const routes: Routes = [
  { path: '', component: SellerComponent},
  { path: 'orders', component: SellerOrdersComponent },
  {path:'returns',component: SellerReturnsComponent},
  {path:'history',component: SellerHistoryComponent},
  {path:'shipping',component:SellerShippingComponent},
  { path: 'addProduct', component: AddProductComponent }


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