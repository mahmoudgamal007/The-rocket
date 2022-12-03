import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductComponent } from './product.component';

const routes: Routes = [
  { path: '', component: ProductComponent },
  { path: 'sellerProdcut/:id', component: ProductComponent, data: { breadcrumb: { alias: 'SellerProduct' } } },
  { path: ':id', component: ProductDetailsComponent, data: { breadcrumb: { alias: 'productDetails' } } }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ProductRoutingModule { }
