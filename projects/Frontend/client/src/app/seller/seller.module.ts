import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SellerComponent } from './seller.component';
import { SellerRoutingModule } from './seller-routing.module';
<<<<<<< HEAD
import { AddProductComponent } from './add-product/add-product.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';

=======
import { SharedModule } from '../shared/shared.module';

import { SellerOrdersComponent } from './seller-orders/seller-orders.component';

>>>>>>> refs/remotes/origin/newDeveloping



@NgModule({
  declarations: [
    SellerComponent,
<<<<<<< HEAD
    SellerOrdersComponent,
    AddProductComponent
=======
    
>>>>>>> refs/remotes/origin/newDeveloping
  ],
  imports: [
    CommonModule,
    SellerRoutingModule,
<<<<<<< HEAD
    FormsModule,
    SharedModule
  ]
=======
    SharedModule
  ],
  exports: [SellerComponent]
>>>>>>> refs/remotes/origin/newDeveloping
})
export class SellerModule { }
