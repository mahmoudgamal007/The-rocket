import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppUser } from 'src/app/shared/models/appUser';
import { Buyer } from 'src/app/shared/models/buyer';
import { IAppUser } from 'src/app/shared/models/IAppUser';
import { Seller } from 'src/app/shared/models/seller';
import { AccountService } from '../../account.service';
import { passwordValidator } from '../../validators/passwordValidator';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerBuyerForm!: FormGroup | null;
  registerSellerForm!: FormGroup | null;
  newBuyer: AppUser = new AppUser();
  newSeller: AppUser = new AppUser();


  genders = [
    { sex: 'Male', value: 0 },
    { sex: 'Female', value: 1 }
  ]

  constructor(private fb: FormBuilder, private router: Router, private accountService: AccountService) { }

  ngOnInit(): void {

  }

  createBuyerRegisterForm() {
    this.registerSellerForm = null;
    this.registerBuyerForm = this.fb.group({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      birthDate: new FormControl('', [Validators.required]),
      gender: new FormControl('', [Validators.required]),
      userName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]),
      password: new FormControl('', [Validators.required, Validators.pattern('^(?=[^\\d_].*?\\d)\\w(\\w|[!@#$%]){7,20}'), passwordValidator('confirmPassword', true)]),
      confirmPassword: new FormControl('', [Validators.required, passwordValidator('password')]),
      accountType: new FormControl('2', [])
    }
    )
  }

  createSellerRegisterForm() {
    this.registerBuyerForm = null;

    this.registerSellerForm = this.fb.group({
      referalCode: new FormControl('', [Validators.required]),
      about: new FormControl('', [Validators.required]),
      brandName: new FormControl('', [Validators.required]),
      userName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]),
      password: new FormControl('', [Validators.required, Validators.pattern('^(?=[^\\d_].*?\\d)\\w(\\w|[!@#$%]){7,20}'), passwordValidator('confirmPassword', true)]),
      confirmPassword: new FormControl('', [Validators.required, passwordValidator('password')]),
      accountType: new FormControl('1', [Validators.required])
    }
    )
  }

  mapRegisterFormValues(values: any) {
    if (this.registerBuyerForm?.value) {
      this.newBuyer.userName = values.userName
      this.newBuyer.email = values.email
      this.newBuyer.password = values.password
      this.newBuyer.confirmPassword = values.confirmPassword
      this.newBuyer.buyer = new Buyer();
      this.newBuyer.buyer!.firstName = values.firstName
      this.newBuyer.buyer!.lastName = values.lastName
      this.newBuyer.buyer!.gender = values.gender
      this.newBuyer.buyer!.birthDate = values.birthDate
      this.newBuyer.accountType= values.accountType
    }

    if (this.registerSellerForm?.value) {
      this.newSeller.userName = values.userName
      this.newSeller.email = values.email
      this.newSeller.password = values.password
      this.newSeller.confirmPassword = values.confirmPassword
      this.newSeller.seller = new Seller();
      this.newSeller.seller!.brandName = values.brandName
      this.newSeller.seller!.referalCode = values.referalCode
      this.newSeller.seller!.referalCode = values.referalCode
      this.newSeller.seller!.about = values.about
      this.newSeller.accountType = values.accountType
    }

  }


  onBuyerSubmit() {
    this.mapRegisterFormValues(this.registerBuyerForm?.value);
    this.accountService.register(this.newBuyer)
      .subscribe(response => { this.router.navigateByUrl('/product'); }, error => { console.log(error) })
  }
  onSellerSubmit() {
    this.mapRegisterFormValues(this.registerSellerForm?.value);
    this.accountService.register(this.newSeller)
      .subscribe(response => { this.router.navigateByUrl('/product'); }, error => { console.log(error) })
  }




}


