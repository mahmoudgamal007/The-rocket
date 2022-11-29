import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountService } from '../account/account.service';
import { IAddress } from '../shared/models/address';
import { IAppUser } from '../shared/models/IAppUser';

import { IUser } from '../shared/models/user';
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
  addresses: IAddress[] | null = null;




  constructor(private buyerService: buyerService, private route: ActivatedRoute, private fb: FormBuilder) {
    this.id = this.route.snapshot.paramMap.get("id")
    console.log(this.id)
  }
  ngOnInit(): void {
    // this.getbuyer();
    // this.editbuyer();
    this.createBuyerEditForm();
  }


  createBuyerEditForm() {
    this.buyerEditForm = this.fb.group(
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
      if (res.buyer?.gender == 0) {
        this.isMale = true
      } else { this.isMale = false; }
      console.log(this.data)
      console.log(res)
    })
  }

  editbuyer() {
    this.buyerService.editbuyer(this.id, this.buyer).subscribe(res => {
      this.data = res
    })
  }
  //   currentUser$!:Observable<IUser|null>;
  //   userId?:string  ='' ;
  //   currentBuyer$!:Observable<IAppUser> ;

  //   constructor(private accountService:AccountService,private buyerService:buyerService ) { }

  //   ngOnInit(): void {
  // this.currentUser$ = this.accountService.currentUser$;
  // this.loadUser();
  // this.loadBuyer();

  //   }

  //   loadUser(){
  //     this.currentUser$.subscribe(response=>{this.userId= response!.userId;},error=>{console.log(error)});
  //   }

  //   loadBuyer(){
  //    this.currentBuyer$ = this.buyerService.getBuyerById(this.userId);
  //   }

  onBuyerEditFormSubmit() {
    console.log(this.buyerEditForm);
  }


}
