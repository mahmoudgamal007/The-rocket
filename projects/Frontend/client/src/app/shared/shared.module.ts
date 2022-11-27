import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule, CarouselModule, PaginationModule } from 'ngx-bootstrap';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { ReactiveFormsModule } from '@angular/forms';
import { PagerComponent } from './components/pager/pager.component';
import { TextInputComponent } from './components/text-input/text-input.component';




@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    TextInputComponent,

  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    ReactiveFormsModule,
    CarouselModule.forRoot(),
    BsDropdownModule.forRoot(),


  ],
  exports: [PaginationModule,
    PagingHeaderComponent,
    ReactiveFormsModule,
    PagerComponent,
    CarouselModule,
    BsDropdownModule, TextInputComponent
  ]
})
export class SharedModule { }
