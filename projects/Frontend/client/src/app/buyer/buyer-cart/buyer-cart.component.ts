import { Component, OnInit } from '@angular/core';
import { ICart } from 'src/app/shared/models/ICart';
import { buyerService } from '../buyer.service';

@Component({
  selector: 'app-buyer-cart',
  templateUrl: './buyer-cart.component.html',
  styleUrls: ['./buyer-cart.component.scss']
})
export class BuyerCartComponent implements OnInit {
  carts: ICart[] = [];
  cartsProductsIds:number[]=[];
  
  constructor(private buyerService: buyerService) { }

  ngOnInit(): void {
  }

  

}
