import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

const routes: Routes = [
  
=======
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
import { ProductComponent } from './product/product.component';

const routes: Routes = [
  { path: 'product', loadChildren: () => import('./product/product.module').then(mod => mod.ProductModule) }
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
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
