import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Feedback } from 'src/app/shared/models/feedback';
import { IAppUser } from 'src/app/shared/models/IAppUser';
import { IFeedBack } from 'src/app/shared/models/IFeedBack';
import { IImage } from 'src/app/shared/models/img';
import { IProduct } from 'src/app/shared/models/IProduct';
import { environment } from 'src/environments/environment';

import { BreadcrumbService } from 'xng-breadcrumb';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  baseUrl: string = environment.apiUrl;
  product!: IProduct;
  quantity = 1;
  productFeedBacks: IFeedBack[] = [];
  feedbackForm!: FormGroup;


  constructor(private shopService: ProductService, private activateRoute: ActivatedRoute, private bcService: BreadcrumbService
    , private fb: FormBuilder) {
    this.bcService.set('@productDetails', '');
  }

  ngOnInit(): void {
    this.loadProduct();
    this.createFeedBackForm();
  }

  createFeedBackForm() {
    this.feedbackForm = this.fb.group({
      rating: [null, [Validators.required, Validators.min(1), Validators.max(5)]],
      comment: [null, [Validators.required]]
    })
  }


  addItemToCart() {
  }

  incrementQuantity() {
    if (this.quantity < this.product.quantity) {
      this.quantity++;
    }
  }

  decrementQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }

  loadProduct() {
    this.shopService.getProduct(+this.activateRoute.snapshot.paramMap.get('id')!).subscribe(product => {
      this.product = product;
      this.bcService.set('@productDetails', product.name);
      this.getFeedBacks();
    }, error => {
      console.log(error);
    });
  }

  getFeedBacks() {
    this.shopService.getFeedbacks(this.product!.id).subscribe(response => { this.productFeedBacks = response },
      error => { console.log(error) })
  }
  onFeedbackSubmit() {

    let feedback = new Feedback();
    feedback.ProductId = this.product.id;
    feedback.Rating = +this.feedbackForm.value.rating;
    feedback.Comment = this.feedbackForm.value.comment;

    this.shopService.getCurrentBuyer().subscribe(response => {
      feedback.BuyerId = response.buyer?.buyerId;
      this.shopService.postFeedback(feedback).subscribe((response) => { }, (error) => { });

    }, error => { console.log(error) })
    this.loadProduct();
    this.loadProduct();

  }



}
