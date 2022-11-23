import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
import { ProductComponent } from './product.component';
import { ProductRoutingModule } from './product-routing.module';
import { SharedModule } from '../shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { ProductItemComponent } from './product-item/product-item.component';

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9



@NgModule({
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
  declarations: [],
  imports: [
    CommonModule
  ]
=======
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
  declarations: [
    ProductComponent,
    ProductItemComponent,

  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    SharedModule,
    
  ],
  exports: []
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
})
export class ProductModule { }
