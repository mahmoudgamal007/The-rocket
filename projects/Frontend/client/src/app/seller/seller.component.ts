import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ProductService } from '../product/product.service';
import { IProduct } from '../shared/models/product';
import { shopParams } from '../shared/models/shopParams';
import { SellerService } from './seller.service';

@Component({
  selector: 'app-seller',
  templateUrl: './seller.component.html',
  styleUrls: ['./seller.component.scss']
})
export class SellerComponent implements OnInit {
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
  orderOptions = [
    { name: 'Ascending', value: 'asc' },
    { name: 'Descending', value: 'desc' },
  ];


  constructor(private sellerService: SellerService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.sellerService.getProducts(this.shopParams).subscribe(
      (response) => {
        this.products = response!.products;
        this.totalCount = response!.productMatchCount;
      },
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

  onOrderSelected(order: string) {

    this.shopParams.sortOrder = order;
    this.getProducts();
  }

  onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }


 

}
