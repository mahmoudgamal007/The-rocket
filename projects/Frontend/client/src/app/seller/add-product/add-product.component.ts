import { formatDate } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Size } from 'src/app/shared/models/Size';
import { Color } from 'src/app/shared/models/Color';
import { SellerService } from '../seller.service';
import { SubCategory } from 'src/app/shared/models/subCategory';
import { HttpEventType, HttpResponse } from '@angular/common/http';
import { SharedService } from 'src/app/shared/shared.service';
import { IProduct } from 'src/app/shared/models/IProduct';
import { visitValue } from '@angular/compiler/src/util';
import { AppUser } from 'src/app/shared/models/appUser';
import { AccountService } from 'src/app/account/account.service';





@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent implements OnInit {
  userId?: string;

  constructor(private service: SellerService, private sharedService: SharedService, private formBuild: FormBuilder, private accountService: AccountService) {
  }

  newProduct: IProduct | undefined

  onAddProduct() {
    console.log('hello');
    this.mapRegisterFormValues(this.addProdcutFrom?.value);
    this.service.postNewProduct(this.newProduct!).subscribe(data => {
      console.log(data)}, error => { console.log(error) }
    );
  }



  mapRegisterFormValues(values: any) {

    this.newProduct!.brand = values.brand;
    this.newProduct!.colors = values.colors;
    this.newProduct!.desctiption = values.desctiption;
    this.newProduct!.discount = values.discount;
    this.newProduct!.imgs = values.imgs;
    this.newProduct!.name = values.name;
    this.newProduct!.price = values.price;
    this.newProduct!.quantity = values.quantity;
    this.newProduct!.sizes = values.sizes;
    this.newProduct!.subCategoryId = values.subCategoryId;

    this.userId != localStorage.getItem('userId');

    this.sharedService.getAppUeserByUsrId(this.userId).subscribe(data => {
      this.newProduct!.sellerId = data.seller!.sellerId;
    }, error => {
      console.log(error);
    })

    this.newProduct!.sellerId = 5;
  }





  createAddProdcutForm() {

    this.addProdcutFrom = this.formBuild.group({
      name: new FormControl('', [Validators.required]),
      desctiption: new FormControl('', [Validators.required]),
      quantity: new FormControl('', [Validators.required]),
      price: new FormControl('', [Validators.required]),
      discount: new FormControl('', [Validators.required]),
      brand: new FormControl('', [Validators.required]),
      SubCategory: new FormControl('', [Validators.required]),
      colors: new FormControl('', [Validators.required]),
      sizes: new FormControl('', [Validators.required])
    }
    )
  }





  public message?: string;
  public progress?: number;
  @Output() public onUploadFinshed = new EventEmitter();
  files: any;
  public catchSelectedImages(files: any) {
    this.files = files
  }
  pths:any; 
  public uploadImage() {
    this.sharedService.uploadImage(this.files).subscribe((event: any) => {
      if (event.type === HttpEventType.UploadProgress) {
        this.progress = Math.round(100 * event.loaded / event.total);
      }
      else if (event.type === HttpEventType.Response) {
        this.message = 'Upload success.';
        console.log(event.body.paths);
        this.newProduct!.imgs=event.body.paths;
      }
    });
  }


  addProdcutFrom?: FormGroup | null;

  colors: Color[] | undefined;
  sizes: Size[] | undefined;
  subCategories: SubCategory[] | undefined;

  ngOnInit(): void {
    this.service.getColors().subscribe(data => {
      this.colors = data
      console.log(this.colors)
    },
      error => {
        console.log(error)
      });

    this.service.getSizes().subscribe(data => {
      this.sizes=data
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
  }


}
