import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr';
// import {BreadCrumbModule} from 'xng-breadcrumb';


@NgModule({
  declarations: [
    NavBarComponent
  ],
  imports: [
    CommonModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true
    }),
    // BreadCrumbModule
  ],
  exports: [
    NavBarComponent,

  ]
})
export class CoreModule { }
