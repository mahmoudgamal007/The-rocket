import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ICart } from 'src/app/shared/models/ICart';
import { Order } from 'src/app/shared/models/order';
import { SharedService } from 'src/app/shared/shared.service';
import { buyerService } from '../buyer.service';

@Component({
  selector: 'app-cart-checkout',
  templateUrl: './cart-checkout.component.html',
  styleUrls: ['./cart-checkout.component.scss']
})
export class CartCheckoutComponent implements OnInit {
  @Input() carts: ICart[] = []
  @Input() cartsPrice: number = 0;
  @Input() cartsDiscount: number = 0;

  constructor(private sharedService: SharedService, private buyerService: buyerService, private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {

  }

  onOrderSubmit() {
    this.carts.forEach((cart) => {
      let order = new Order();
      order.quantity = cart.quantity;
      order.sellerId = cart.product.sellerId;
      order.productId = cart.product.id;
      order.productName = cart.product.name;
      order.productPrice = cart.product.price - (cart.product.price * (cart.product.discount / 100));
      this.sharedService.getCurrentAppUser().subscribe(res => {
        order.buyerId = res.buyer?.buyerId;
        this.buyerService.postOrder(order).subscribe(resp => {
          this.buyerService.removeFromCart(cart.id).subscribe(res => {
            this.toastr.success('Successfully Submited ur order');
            this.router.navigateByUrl('/buyer/order');
          })

        }, err => { console.log(err) });
      }, err => { console.log(err) })
    })
  }


}
