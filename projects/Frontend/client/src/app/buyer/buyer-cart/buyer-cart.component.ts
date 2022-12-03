import { Component, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { delay } from 'rxjs/operators';
import { ICart } from 'src/app/shared/models/ICart';
import { SharedService } from 'src/app/shared/shared.service';
import { buyerService } from '../buyer.service';

@Component({
  selector: 'app-buyer-cart',
  templateUrl: './buyer-cart.component.html',
  styleUrls: ['./buyer-cart.component.scss']
})
export class BuyerCartComponent implements OnInit {
  carts: ICart[] = [];
  cartsTotalPrice = 0;
  cartsTotalDiscount = 0;

  cartsTotalPriceWithoutDiscount = 0;



  constructor(private buyerService: buyerService, private sharedService: SharedService, private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.LoadCurrentBuyerCarts();
  }

  LoadCurrentBuyerCarts() {
    this.sharedService.getCurrentAppUser().subscribe(res => {
      this.buyerService.getCurrentCartsByBuyerId(res.buyer?.buyerId!).subscribe(res => {
        this.carts = res;
        this.carts.forEach((cart) => {
          this.cartsTotalPrice += (cart.product.price - (cart.product.price * (cart.product.discount / 100))) * cart.quantity;
          this.cartsTotalDiscount += cart.product.price * (cart.product.discount / 100)
        })

      }, err => { console.log(err) })
    }, err => { console.log(err) });
  }

  removeFromCart(cart: ICart) {
    this.buyerService.removeFromCart(cart.id).subscribe(resp => {
      this.toastrService.info(`${cart.quantity} of ${cart.product.name} has been removed from the cart`);
    }, err => { console.log(err) });
    delay(500)
    this.LoadCurrentBuyerCarts();
  }

}
