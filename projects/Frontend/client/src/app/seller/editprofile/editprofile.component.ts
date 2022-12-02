import { Component, OnInit } from '@angular/core';
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
  constructor(
    private sellerservice: SellerService,
    private route: ActivatedRoute,
    private accountservice: AccountService
  ) {}

  ngOnInit(): void {
    this.accountservice.currentUser$
      .pipe(filter((res) => res != null))
      .subscribe((res) => {
        this.id = res?.userId;
        this.sellerid = res?.accountId;
        this.getseller();
        this.editSeller();
        console.log(localStorage.getItem('userId'));
      });
  }
  getseller() {
    this.sellerservice.getCurrentSeller().subscribe((res) => {
      console.log(res);
    });
  }
  editSeller() {
    let seller: AppUser = new AppUser();
    console.log(this.data);
    this.sellerservice.editSeller(this.id, this.data).subscribe((res) => {
      alert('Edit Info Success');
    });
  }
}
