import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { Breadcrumb } from 'xng-breadcrumb/lib/breadcrumb';
import { SellerService } from '../seller/seller.service';
import { IProduct } from '../shared/models/IProduct';
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
  orderOptions = [
    { name: 'Ascending', value: 'asc' },
    { name: 'Descending', value: 'desc' },
  ];
  categoryOptions = [
    { name: 'All', value: '' },
    { name: 'Men', value: 'Men' },
    { name: 'Women', value: 'Woman' },
    { name: 'Children', value: 'Childreen' }

  ];
  subCategoryOptions = [
    { name: 'All', value: '' },
    { name: 'Clothes', value: 'clothes' },
    { name: 'Shoes', value: 'shoes' },
    { name: 'Accessories', value: 'Accessories' }
  ];


  sellerId!: number;
  brandName!: string;
  seller: any
  constructor(private productService: ProductService, private activateRoute: ActivatedRoute, private bcService: BreadcrumbService, private sellerService: SellerService) {

    this.sellerId = +this.activateRoute.snapshot.paramMap.get('id')!;
    if (this.sellerId > 0) {
      this.shopParams.sellerId = this.sellerId;
      sellerService.getSellerNameBySellerId(this.sellerId).subscribe(data => {
        this.seller = data;
        this.brandName = this.seller.brandName;
        this.bcService.set('@SellerProduct', this.brandName);
      }, error => {
        console.log(error);
      });

      

    }
    this.getProducts();
  }


  ngOnInit(): void {

  }

  getProducts() {
    this.productService.getProducts(this.shopParams).subscribe(
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

  onCategorySelected(value: string) {
    this.shopParams.mainCategory = value;
    this.getProducts();
  }

  onSubCategorySelected(value: string) {
    this.shopParams.subCategory = value;
    this.getProducts();

  }

}
