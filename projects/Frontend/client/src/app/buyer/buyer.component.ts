import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { IAddress } from '../shared/models/address';
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
  constructor(private buyerService: buyerService, private route: ActivatedRoute, private fb: FormBuilder) {
    // this.id = this.route.snapshot.paramMap.get("id")
    // console.log(this.id)
  }
  ngOnInit(): void {
    this.createBuyerEditForm();
    this.createBuyerEditAddressForm();
    this.getbuyer();
    // this.Editbuyer();
   this.onBuyerEditFormSubmit(); 
   this.onBuyerEditAddressFormSubmit(); 
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
    const buyer=this.buyerEditForm.value;
    buyer.id = localStorage.getItem('userId');
    this.buyerService.editbuyer(this.id,buyer).subscribe(res => {
      alert("Edit Info Success")
    })
  }
  onBuyerEditAddressFormSubmit() {
    const address=this.buyerEditAddressForm.value;
    console.log(address)
    address.id = localStorage.getItem('userId');
    this.buyerService.editAddressbuyer(this.id,address).subscribe(res => {
      alert("Edit Address Success")
    })
  }
}
