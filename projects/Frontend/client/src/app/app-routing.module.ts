import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';

const routes: Routes = [
  { path: 'product', loadChildren: () => import('./product/product.module').then(mod => mod.ProductModule), },
  { path: 'cart', loadChildren: () => import('./cart/cart.module').then(mod => mod.CartModule) },
  { path: 'buyer', loadChildren: () => import('./buyer/buyer.module').then(mod => mod.BuyerModule) },
  { path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule) },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
