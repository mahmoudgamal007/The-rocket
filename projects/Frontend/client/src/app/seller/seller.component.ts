import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { filter, tap } from 'rxjs/operators';
import { AccountService } from '../account/account.service';
import { ProductService } from '../product/product.service';
import { IAppUser } from '../shared/models/IAppUser';
import { IUser } from '../shared/models/user';
import { SellerService } from './seller.service';
import { shopParams } from '../shared/models/shopParams';

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
  ) {}

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
}
