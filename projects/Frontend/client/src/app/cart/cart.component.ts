import { Component, OnInit } from '@angular/core';
import { ICart } from '../shared/models/cart';
import { CartService } from './cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  carts:ICart[]=[];

  constructor(private cartService:CartService) { }

  ngOnInit(): void {
    this.getCarts();
    console.log(this.carts);
  }
  getCarts()
  {
    return this.cartService.getCarts(1).subscribe(
      response=>{this.carts=response;},
      error=>{console.log(error);}

    )
  }

}
