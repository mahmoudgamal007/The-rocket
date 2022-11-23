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
  products: IProduct[] | undefined = [];
  shopParams = new shopParams();
  totalCount: number = 0;
  sortOptions = [
    { name: 'Alphabetical', value: 'Name' },
    { name: 'Price', value: 'Price' },
    { name: 'Brand', value: 'Brand' },
    { name: 'Seller', value: 'SellerId' },
    { name: 'Category', value: 'subCategoryId' },
  ];


  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.productService.getProducts(this.shopParams).subscribe(
      (response) => { this.products = response?.products },
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

  onSortSelected(sort: string) {
    this.shopParams.sortBy = sort;
    this.getProducts();
  }

  onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }

}
