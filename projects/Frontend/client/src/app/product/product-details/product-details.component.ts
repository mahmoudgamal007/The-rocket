import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Address } from 'src/app/shared/models/address';
import { Cart } from 'src/app/shared/models/cart';
import { Feedback } from 'src/app/shared/models/feedback';
import { IAppUser } from 'src/app/shared/models/IAppUser';
import { IFeedBack } from 'src/app/shared/models/IFeedBack';
import { IImage } from 'src/app/shared/models/img';
import { IProduct } from 'src/app/shared/models/IProduct';
import { SharedService } from 'src/app/shared/shared.service';
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
  productFeedBacks: Feedback[] = [];
  feedbackForm!: FormGroup;
  addresses:any=[{id:1,address:'addr1'},{id:2,address:'addr2'},{id:3,address:'addr3'}]


  constructor(private shopService: ProductService, private activateRoute: ActivatedRoute, private bcService: BreadcrumbService
    , private fb: FormBuilder, private sharedService: SharedService, private ts: ToastrService) {
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
    let cart = new Cart();
    cart.quantity = this.quantity;
    cart.productId = this.product.id;
    this.sharedService.getAppUeserByUsrId(localStorage.getItem('userId')).subscribe(resp => {
      cart.buyerId = resp.buyer?.buyerId;
      this.shopService.addItemToCart(cart).subscribe(resp => {
        console.log(resp);
        this.ts.success(`${cart.quantity} pcs of ${this.product.name} has been added to your cart`)
      }, err => { console.log(err) });
    });
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
      error => { })
  }
  onFeedbackSubmit() {

    let feedback = new Feedback();

    feedback.productId = this.product.id;
    feedback.rating = +this.feedbackForm.value.rating;
    feedback.comment = this.feedbackForm.value.comment;
    feedback.createdAt = new Date();
    this.shopService.getCurrentBuyer().subscribe(response => {
      feedback.buyerId = response.buyer?.buyerId;
      this.shopService.postFeedback(feedback).subscribe((response) => { this.ts.success('Feedback has been submitted') }, (error) => { });
    }, error => { console.log(error) })
    this.productFeedBacks.push(feedback);
    this.loadProduct();
  }

  EditAddress(value:any){
    console.log(value)
  }

}
