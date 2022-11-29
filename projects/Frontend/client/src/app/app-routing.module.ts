import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { SellerComponent} from './seller/seller.component'

const routes: Routes = [
  { path: 'product', loadChildren: () => import('./product/product.module').then(mod => mod.ProductModule), },

  { path: 'seller', loadChildren: () => import('./seller/seller.module').then(mod => mod.SellerModule) },
  { path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule) },
  { path: 'seller', loadChildren: () => import('./seller/seller.module').then(mod => mod.SellerModule) },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
