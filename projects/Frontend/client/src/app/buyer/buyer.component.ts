import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AppUser } from '../shared/models/appUser';
import { Buyer } from '../shared/models/buyer';
import { buyerService } from './buyer.service';
import { Address } from '../shared/models/address';
import { Phone } from '../shared/models/phone';

@Component({
  selector: 'app-buyer',
  templateUrl: './buyer.component.html',
  styleUrls: ['./buyer.component.scss']
})
export class BuyerComponent implements OnInit {
  id: any
  isMale: string = "Female"
  buyer: any = {}
  data!: any;
  buyerEditForm!: FormGroup;
  buyerEditAddressForm!: FormGroup;
  buyerAddAddressForm!: FormGroup;
  buyerEditPhoneForm!: FormGroup;
  buyerAddPhoneForm!: FormGroup;
  addresses: Address[] = [];
  phoneNumbers: Phone[]=[];
  appuser!: AppUser;
  constructor(private buyerService: buyerService, private route: ActivatedRoute, private fb: FormBuilder) {
    // this.id = this.route.snapshot.paramMap.get("id")
    // console.log(this.id)
  }
  ngOnInit(): void {
    this.createBuyerEditForm();
    this.getbuyer();
    // this.Editbuyer();

  }

  getbuyer() {
    this.buyerService.getCurrentBuyer().subscribe(res => {
      this.data = res
      this.data.buyer = res.buyer
      console.log(res)
      if(res.buyer?.gender==0){
        this.isMale="Male";
      }
    })
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
  createBuyerEditAddressForm(value:any) {
    let Id=value.id;
    this.buyerEditAddressForm = this.fb.group(
      {
        editcountry: new FormControl(value.country, [Validators.required]),
        editgovernment: new FormControl(value.government, [Validators.required]),
        editcity: new FormControl(value.city, [Validators.required]),
        editstreet: new FormControl(value.street, [Validators.required]),
        id: new FormControl(value.id, [Validators.required]),
      }
    )
  }
  newbuyer: AppUser = new AppUser();
  nbuyer:Buyer = new Buyer();

  onBuyerEditFormSubmit(fname:any,lname:any,bDate:any,uname:any) {
     this.data.buyer.firstName=this.buyerEditForm.value.firstName;
    this.data.buyer.lastName=this.buyerEditForm.value.lastName;
    this.data.buyer.birthDate=this.buyerEditForm.value.birthDate;
    if(this.buyerEditForm.value.firstName===''){
      this.data.buyer.firstName=fname;
    }
    if(this.buyerEditForm.value.lastName===''){
      this.data.buyer.lastName=lname;
    }
    if(this.buyerEditForm.value.birthDate===''){
      this.data.buyer.birthDate=bDate;
    }
    this.newbuyer=this.data;
    this.buyerService.editbuyer(this.id,this.newbuyer).subscribe(res => {
      alert("Edit Info Success")
    })
  }
  
  onBuyerEditAddressFormSubmit() {

    let address:Address = new Address();
    address.id = this.buyerEditAddressForm.value.id;
    address.country=this.buyerEditAddressForm.value.editcountry;
    address.government=this.buyerEditAddressForm.value.editgovernment;
    address.city=this.buyerEditAddressForm.value.editcity;
    address.street=this.buyerEditAddressForm.value.editstreet;
    address.appUserId=localStorage.getItem('userId')!;
    // address.id = localStorage.getItem('userId');
    this.buyerService.editAddressbuyer(this.id, address).subscribe(res => {
      alert("Edit Address Success")
    
    })
  }
  onBuyerAddAddressFormSubmit(){
    let address:Address = new Address();
    address.country=this.buyerAddAddressForm?.value.addcountry
    address.government=this.buyerAddAddressForm?.value.addgovernment;
    address.city=this.buyerAddAddressForm?.value.addcity;
    address.street=this.buyerAddAddressForm?.value.addstreet;
    address.appUserId=localStorage.getItem('userId')!;
    this.buyerService.addAddressbuyer(address).subscribe(res => {
      alert("Add Address Success")
    })

  }
  createBuyerAddAddressForm() {
    this.buyerAddAddressForm = this.fb.group(
      {
        addcountry: new FormControl('', [Validators.required]),
        addgovernment: new FormControl('', [Validators.required]),
        addcity: new FormControl('', [Validators.required]),
        addstreet: new FormControl('', [Validators.required]),
      }
   )
 }
  onBuyerDeleteAddress(value:any){
    this.buyerService.deleteAddressbuyer(value.id).subscribe(res => {
      alert("Delete Address Success")
    })
}
createBuyerEditPhoneForm(value:any){
this.buyerEditPhoneForm=this.fb.group({
  editphone:new FormControl(value.phone,[Validators.required]),
  id:new FormControl(value.id,[Validators.required])
})


}
onBuyerEditPhoneFormSubmit() {
  let phone:Phone = new Phone();
  phone.id = this.buyerEditPhoneForm.value.id;
  phone.phone=this.buyerEditPhoneForm.value.editphone;
  phone.appUserId=localStorage.getItem('userId')!;
  this.buyerService.editPhonebuyer(this.id,phone).subscribe(res => {
    alert("Edit Phone Success")
  })
}
onBuyerAddPhoneFormSubmit(){
  let phone:Phone = new Phone();
  phone.phone=this.buyerAddPhoneForm.value.addphone;
  phone.appUserId=localStorage.getItem('userId')!;
  this.buyerService.addPhonebuyer(phone).subscribe(res => {
    alert("Add Phone Success")
  })

}
createBuyerAddPhoneForm() {
  this.buyerAddPhoneForm = this.fb.group(
    {
      addphone: new FormControl('', [Validators.required])
      // id: new FormControl(value.id, [Validators.required]),
    }
 )
}
onBuyerDeletePhone(value:any){
  this.buyerService.deletePhonebuyer(value.id).subscribe(res => {
    alert("Delete Phone Success")
  })
}
}
