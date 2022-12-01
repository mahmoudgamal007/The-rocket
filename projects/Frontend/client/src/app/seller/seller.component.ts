import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { filter, tap } from 'rxjs/operators';
import { AccountService } from '../account/account.service';
import { ProductService } from '../product/product.service';
import { IAppUser } from '../shared/models/IAppUser';
import { IUser } from '../shared/models/user';
import { SellerService } from './seller.service';
import { shopParams } from '../shared/models/shopParams';
import { Product } from '../shared/models/product';
import { Color } from '../shared/models/Color';
import { Image } from '../shared/models/image';

@Component({
  selector: 'app-seller',
  templateUrl: './seller.component.html',
  styleUrls: ['./seller.component.scss'],
})
export class SellerComponent implements OnInit {
  appUser!: IAppUser;
  currentUser!: IUser | null;
  shopParams = new shopParams();

  id!: any;
  sellerid!: any;
  products: any[] = [];
  constructor(
    private accountService: AccountService,
    private sellerService: SellerService
  ) { }

  ngOnInit(): void {
    this.accountService.currentUser$
      .pipe(filter((res) => res != null))
      .subscribe((res) => {
        this.id = res?.userId;
        this.sellerid = res?.accountId;
        this.shopParams.sellerId = this.sellerid;
        this.getUser();
        this.getProducts();
      });
  }

  getProducts() {
    this.sellerService.getProducts(this.shopParams).subscribe(
      (response) => {
        this.products = response!.products;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getUser() {
    return this.sellerService.getUser(this.id).subscribe(
      (response) => {
        this.appUser = response;
        this.sellerid = response.seller?.sellerId;
        console.log(this.appUser);
      },
      (error) => {
        console.log(error);
      }
    );
  }
  addProd() {
    let prod = new Product();
    prod.brand = 'sadsadsa'
    prod.colors = ['red', 'green'];
    prod.sizes = ['small', 'large'];
    prod.desctiption = 'sadasda';
    prod.imgs = [new Image(), new Image()];
    prod.price = 1200;
    prod.discount = 12;
    prod.quantity = 19;
    prod.sellerId = this.appUser.seller?.sellerId;
    prod.subCategoryId = 1;
    console.log(prod);
    this.sellerService.postNewProduct(prod).subscribe(resp => { console.log(resp) }, error => { console.log(error) });
  }
}
