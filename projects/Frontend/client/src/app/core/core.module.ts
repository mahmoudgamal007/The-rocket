import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

=======
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr';
// import {BreadCrumbModule} from 'xng-breadcrumb';
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr';
// import {BreadCrumbModule} from 'xng-breadcrumb';
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr';
// import {BreadCrumbModule} from 'xng-breadcrumb';
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr';
// import {BreadCrumbModule} from 'xng-breadcrumb';
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9


@NgModule({
  declarations: [
    NavBarComponent
  ],
  imports: [
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    CommonModule
=======
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
    CommonModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true
    }),
    // BreadCrumbModule
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
  ],
  exports: [
    NavBarComponent,

  ]
})
export class CoreModule { }
