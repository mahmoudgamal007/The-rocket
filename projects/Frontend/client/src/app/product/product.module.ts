import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product.component';
import { ProductRoutingModule } from './product-routing.module';
import { SharedModule } from '../shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { ProductItemComponent } from './product-item/product-item.component';
import { ProductDetailsComponent } from './product-details/product-details.component';




@NgModule({
  declarations: [
    ProductComponent,
    ProductItemComponent,
    ProductDetailsComponent,

  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    SharedModule,
    
  ],
  exports: []
})
export class ProductModule { }
