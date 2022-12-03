import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ICart } from 'src/app/shared/models/ICart';
import { buyerService } from '../buyer.service';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.scss']
})
export class CartItemComponent implements OnInit {
  @Input() cart!: ICart;
  constructor(private buyerService: buyerService, private toastrService: ToastrService) { }

  ngOnInit(): void {
  }


  removeFromCart(cart: ICart) {
    this.buyerService.removeFromCart(cart.id).subscribe(resp => {
      this.toastrService.info(`${cart.quantity} of ${cart.product.name} has been removed from the cart`);
    }, err => { console.log(err) });
  }
}
