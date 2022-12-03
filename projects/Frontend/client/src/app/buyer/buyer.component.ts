import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { IAddress } from '../shared/models/IAddress';
import { AppUser } from '../shared/models/appUser';
import { Buyer } from '../shared/models/buyer';
import { buyerService } from './buyer.service';

@Component({
  selector: 'app-buyer',
  templateUrl: './buyer.component.html',
  styleUrls: ['./buyer.component.scss']
})
export class BuyerComponent implements OnInit {
  id: any
  isMale: boolean = false
  buyer: any = {}
  data!: any;
  buyerEditForm!: FormGroup;
  buyerEditAddressForm!: FormGroup;
  addresses: IAddress[] = [];
  appuser!: AppUser;
  constructor(private buyerService: buyerService, private route: ActivatedRoute, private fb: FormBuilder) {
    // this.id = this.route.snapshot.paramMap.get("id")
    // console.log(this.id)
  }
  ngOnInit(): void {
    this.createBuyerEditForm();
    this.createBuyerEditAddressForm();
    this.getbuyer();
    // this.Editbuyer();

  }
  createBuyerEditForm() {
    this.buyerEditForm = this.fb.group(
      {
        firstName: new FormControl('', [Validators.required]),
        lastName: new FormControl('', [Validators.required]),
        userName: new FormControl('', [Validators.required]),
        email: new FormControl('', [Validators.required]),
        birthDate: new FormControl('', [Validators.required]),
        gender: new FormControl('', [Validators.required]),
      }
    )
  }
  createBuyerEditAddressForm() {
    this.buyerEditAddressForm = this.fb.group(
      {
        country: new FormControl('', [Validators.required]),
        government: new FormControl('', [Validators.required]),
        city: new FormControl('', [Validators.required]),
        street: new FormControl('', [Validators.required]),
      }
    )
  }
  getbuyer() {
    this.buyerService.getCurrentBuyer().subscribe(res => {
      this.data = res
      this.data.buyer = res.buyer
      console.log(res)
    })
  }
  onBuyerEditFormSubmit() {
    let buyer: AppUser = new AppUser();
    buyer.id = localStorage.getItem('userId')!;
    buyer.userName = this.buyerEditForm.value.userName
    buyer.buyer = new Buyer();
    buyer.buyer.buyerId = this.data.buyer.buyerId;
    buyer.buyer.appUserId = localStorage.getItem('userId')!;
    buyer.buyer.firstName = this.buyerEditForm.value.firstName
    buyer.buyer.lastName = this.buyerEditForm.value.firstName
    buyer.buyer.gender = this.buyerEditForm.value.gender
    buyer.buyer.birthDate = this.buyerEditForm.value.birthDate
    console.log(buyer)
    this.buyerService.editbuyer(this.id, buyer).subscribe(res => {
      alert("Edit Info Success")
    })
  }
  onBuyerEditAddressFormSubmit() {
    const address = this.buyerEditAddressForm.value;
    console.log(address)
    address.id = localStorage.getItem('userId');
    this.buyerService.editAddressbuyer(this.id, address).subscribe(res => {
      alert("Edit Address Success")
    })
  }
}
