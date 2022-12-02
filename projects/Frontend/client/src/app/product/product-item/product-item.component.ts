import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from 'src/app/account/account.service';
import { Cart } from 'src/app/shared/models/cart';
import { IProduct } from 'src/app/shared/models/IProduct';
import { IUser } from 'src/app/shared/models/user';
import { SharedService } from 'src/app/shared/shared.service';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  @Input() product!: IProduct;
  currentUser$: Observable<IUser>;
  constructor(private shopService: ProductService, private accountService: AccountService, private sharedService: SharedService, private toastrservice: ToastrService) {
    this.currentUser$ = this.accountService.currentUser$
  }

  ngOnInit(): void {
  }


  addItemToCart() {
    let cart = new Cart();
    cart.productId = this.product.id;
    cart.quantity = 1;
    this.sharedService.getAppUeserByUsrId(localStorage.getItem('userId')).subscribe(
      res => {
        cart.buyerId = res.buyer?.buyerId;
        this.shopService.addItemToCart(cart).subscribe(res => { this.toastrservice.info(`1 pc of ${this.product.name} has been added to your cart `, 'Cart') }, err => { });
      }, err => { console.log(err) })
  }
}
