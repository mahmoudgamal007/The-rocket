import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { filter, tap } from 'rxjs/operators';
import { AccountService } from '../account/account.service';
import { ProductService } from '../product/product.service';
import { IAppUser } from '../shared/models/IAppUser';
import { IProduct } from '../shared/models/product';
import { IUser } from '../shared/models/user';
import { SellerService } from './seller.service';

@Component({
  selector: 'app-seller',
  templateUrl: './seller.component.html',
  styleUrls: ['./seller.component.scss'],
})
export class SellerComponent implements OnInit {
  appUser!: IAppUser;
  currentUser!: IUser | null;
  id!: any;
  products: IProduct[] = [];
  constructor(
    private accountService: AccountService,
    private sellerService: SellerService
  ) {}

  ngOnInit(): void {
    this.accountService.currentUser$
      .pipe(filter((res) => res != null))
      .subscribe((res) => {
        this.id = res?.userId;
        this.getUser();
        // this.getproducts();
      });
  }

  // getproducts() {
  //   return this.sellerService.getProducts(6).subscribe(
  //     (resp) => {
  //       this.products = resp;
  //     },
  //     (error) => {
  //       console.log(error);
  //     }
  //   );
  // }

  // this.getUser();

  // }
  getUser() {
    return this.sellerService.getUser(this.id).subscribe(
      (response) => {
        this.appUser = response;
        console.log(this.appUser);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
