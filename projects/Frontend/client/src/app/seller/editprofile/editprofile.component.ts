import { HttpEventType } from '@angular/common/http';
import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { filter } from 'rxjs/operators';
import { AccountService } from 'src/app/account/account.service';
import { AppUser } from 'src/app/shared/models/appUser';
import { IAppUser } from 'src/app/shared/models/IAppUser';
import { Seller } from 'src/app/shared/models/seller';
import { SharedService } from 'src/app/shared/shared.service';
import { SellerService } from '../seller.service';

@Component({
  selector: 'app-editprofile',
  templateUrl: './editprofile.component.html',
  styleUrls: ['./editprofile.component.scss'],
})
export class EditprofileComponent implements OnInit {
  appUser!: IAppUser;
  data!: any;
  accountService: any;
  id: any;
  sellerid: any;
  i: number = 1;
  sellerEditForm!: FormGroup;
  sellerAdressForm!: FormGroup;
  constructor(
    private sellerservice: SellerService,
    private route: ActivatedRoute,
    private accountservice: AccountService,
    private fb: FormBuilder,
    private sharedService: SharedService
  ) {}

  ngOnInit(): void {
    this.accountservice.currentUser$
      .pipe(filter((res) => res != null))
      .subscribe((res) => {
        this.id = res?.userId;
        this.sellerid = res?.accountId;
        this.getseller();

        this.id = localStorage.getItem('userId');
        console.log(this.data);
      });
  }
  createSellerEditAddressForm() {
    this.sellerAdressForm = this.fb.group({
      country: new FormControl('', [Validators.required]),
      government: new FormControl('', [Validators.required]),
      city: new FormControl('', [Validators.required]),
      street: new FormControl('', [Validators.required]),
    });
  }
  onSellerEditAddressFormSubmit() {
    const address = this.sellerAdressForm.value;
    console.log(address);
    address.id = localStorage.getItem('userId');
    this.sellerservice.editAdress(this.id, address).subscribe((res) => {
      alert('Edit Address Success');
    });
  }
  getseller() {
    this.sellerservice.getCurrentSeller().subscribe((res) => {
      this.data = res;
      this.data.seller = res.seller;
    });
  }
  createSellerEditForm() {
    this.sellerEditForm = this.fb.group({
      About: new FormControl('', [Validators.required]),
    });
  }
  // editSeller() {
  //   let seller: AppUser = new AppUser();
  //   console.log(this.data);
  //   this.data.seller.about = 'updated';
  //   this.sellerservice.editSeller(this.id, this.data).subscribe((res) => {
  //     alert('Edit Info Success');
  //   });
  // }
  newperson: AppUser = this.data;
  onSellerEditFormSubmit() {
    const about = document.getElementById('about') as HTMLInputElement | null;

    const value = about?.value;
    this.newperson.seller!.about = value;
    this.newperson.seller!.profileImageUrl = this.newpp;
    this.sellerservice.editSeller(this.id, this.newperson).subscribe((res) => {
      alert('Edit Info Success');
    });
  }
  newpp: any;
  public onSubmit() {
    let newperson: AppUser = this.data;
    if (!(this.files === undefined || this.files.length == 0)) {
      this.sharedService.uploadImage(this.files).subscribe((event: any) => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round((100 * event.loaded) / event.total);
        } else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          console.log(event.body.paths);

          newperson.seller!.profileImageUrl = event.body.paths[0];
          this.sellerservice.editSeller(this.id, newperson).subscribe(
            (data) => {
              this.newpp = data.toString();
              console.log(this.newpp);
            },
            (error) => {
              console.log(error);
            }
          );
        }
      });
    }
  }
  public message?: string;
  public progress?: number;
  @Output() public onUploadFinshed = new EventEmitter();
  files: any;
  public catchSelectedImages(files: any) {
    this.files = files;
    console.log('hello');
  }
}
