import { HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { filter } from 'rxjs/operators';
import { AccountService } from 'src/app/account/account.service';
import { AppUser } from 'src/app/shared/models/appUser';
import { IAppUser } from 'src/app/shared/models/IAppUser';
import { SharedService } from 'src/app/shared/shared.service';
import { SellerService } from '../seller.service';

@Component({
  selector: 'app-editcover',
  templateUrl: './editcover.component.html',
  styleUrls: ['./editcover.component.scss'],
})
export class EditcoverComponent implements OnInit {
  constructor(
    private sellerservice: SellerService,
    private route: ActivatedRoute,
    private accountservice: AccountService,
    private fb: FormBuilder,
    private sharedService: SharedService
  ) {}
  appUser!: IAppUser;
  data!: any;
  accountService: any;
  id: any;
  sellerid: any;
  i: number = 1;
  sellerEditForm!: FormGroup;
  sellerAdressForm!: FormGroup;
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
  newpp: any;
  getseller() {
    this.sellerservice.getCurrentSeller().subscribe((res) => {
      this.data = res;
      this.data.seller = res.seller;
    });
  }
  public onSubmit() {
    let newperson: AppUser = this.data;
    if (!(this.files === undefined || this.files.length == 0)) {
      this.sharedService.uploadImage(this.files).subscribe((event: any) => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round((100 * event.loaded) / event.total);
        } else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          console.log(event.body.paths);

          newperson.seller!.coverImageUrl = event.body.paths[0];
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
