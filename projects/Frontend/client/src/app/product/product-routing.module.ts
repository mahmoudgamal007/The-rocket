import { NgModule } from '@angular/core';
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
import { CommonModule } from '@angular/common';


=======
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product.component';

const routes: Routes = [
  { path: '', component: ProductComponent }
]
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9

@NgModule({
  declarations: [],
  imports: [
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    CommonModule
  ]
=======
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
})
export class ProductRoutingModule { }
