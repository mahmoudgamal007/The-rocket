import { formatDate } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Size } from 'src/app/shared/models/Size';
import { Color } from 'src/app/shared/models/Color';
import { SellerService } from '../seller.service';
import { SubCategory } from 'src/app/shared/models/subCategory';
import { HttpEventType, HttpResponse } from '@angular/common/http';
import { SharedService } from 'src/app/shared/shared.service';
import { Product } from 'src/app/shared/models/Product';
import { visitValue } from '@angular/compiler/src/util';
import { AppUser } from 'src/app/shared/models/appUser';
import { AccountService } from 'src/app/account/account.service';
import { map } from 'rxjs/operators';
import { observable, Observable } from 'rxjs';





@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent implements OnInit {
  userId?: string;
  addProdcutFrom!: FormGroup | null;
  colors: Color[] | undefined;
  sizes: Size[] | undefined;
  subCategories: SubCategory[] | undefined;
  newProduct: Product = new Product();
  accountId = localStorage.getItem('accountId')
  constructor(private service: SellerService, private sharedService: SharedService, private formBuild: FormBuilder, private accountService: AccountService) {
  }


  ngOnInit(): void {


    this.service.getColors().subscribe(data => {
      this.colors = data
      console.log(this.colors)
    },
      error => {
        console.log(error)
      });

    this.service.getSizes().subscribe(data => {
      this.sizes = data
      console.log(this.colors)
    },
      error => {
        console.log(error)
      });

    this.service.getSubCategory().subscribe(data => {
      this.subCategories = data
      console.log(this.subCategories)
    },
      error => {
        console.log(error)
      });

    this.createAddProdcutForm();
  }



  // onSubmit() {

  //   this.uploadImage().pipe(map(response => {
  //     if (response === true) {
      
  //     }
  //   }
  //   ))

  // }





  mapAddProductFromValues(values: any) {

    this.newProduct.brand = values.brand;
    this.newProduct.ColorIds = values.colors;
    this.newProduct.desctiption = values.desctiption;
    this.newProduct.discount = values.discount;
    this.newProduct.name = values.name;
    this.newProduct.price = values.price;
    this.newProduct.quantity = values.quantity;
    this.newProduct.SizeIds = values.sizes;
    this.newProduct.subCategoryId = values.subCategory;
    this.newProduct.sellerId = +this.accountId!;
  }





  createAddProdcutForm() {
    this.addProdcutFrom = this.formBuild.group({
      name: new FormControl('', [Validators.required]),
      desctiption: new FormControl('', [Validators.required]),
      quantity: new FormControl('', [Validators.required]),
      price: new FormControl('', [Validators.required]),
      brand: new FormControl('', [Validators.required]),
      subCategory: new FormControl('', [Validators.required]),
      discount: new FormControl(),
      colors: new FormControl('', [Validators.required]),
      sizes: new FormControl('', [Validators.required]),
      file: new FormControl(null, [Validators.required])
    }
    )
  }





  public message?: string;
  public progress?: number;
  @Output() public onUploadFinshed = new EventEmitter();
  files: any;
  public catchSelectedImages(files: any) {
    this.files = files;
    console.log('hello');
  }


  public onSubmit() {

    if (!(this.files === undefined || this.files.length == 0)) {
      this.sharedService.uploadImage(this.files).subscribe((event: any) => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
        }
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.newProduct.ImgUrls = event.body.paths;
          this.mapAddProductFromValues(this.addProdcutFrom?.value);
          console.log(this.newProduct);
          this.service.postNewProduct(this.newProduct).subscribe(data => {
            console.log(data)
          }, error => { console.log(error) });
        }
      });
    }
   
  }





}


