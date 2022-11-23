import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { shopParams } from '../shared/models/shopParams';
import { ProductService } from './product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  @ViewChild('search', { static: false }) searchTermVC!: ElementRef;
  products: IProduct[] | null = [];
  shopParams = new shopParams();
  totalCount: number = 0;




  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.productService.getProducts(this.shopParams).subscribe(
      (response) => { this.products = response },
      (error) => { console.log(error) });
  }

  onSearch() {
    this.shopParams.searchTerm = this.searchTermVC.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onReset() {
    this.searchTermVC.nativeElement.value = '';
    this.shopParams = new shopParams();
    this.getProducts();
  }

}
