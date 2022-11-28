import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AccountService } from '../account/account.service';
import { ProductService } from '../product/product.service';
import { IAppUser } from '../shared/models/appUser';
import { IProduct } from '../shared/models/product';
import { IUser } from '../shared/models/user';
import { SellerService } from './seller.service';

@Component({
  selector: 'app-seller',
  templateUrl: './seller.component.html',
  styleUrls: ['./seller.component.scss']
})
export class SellerComponent implements OnInit {
  appUser!: IAppUser;
  currentUser$!:Observable<IUser|null>;
  id!: any;
  products:IProduct[]=[];
  constructor(private accountService : AccountService ,private sellerService : SellerService ) { }

  ngOnInit(): void {
    this.currentUser$=this.accountService.currentUser$;

    //  this.currentUser$.subscribe(response=>{this.id=response!.userId;},error=>{console.log(error);})
    // this.id=this.currentUser$.subscribe(response=>{this.id=response?.userId;},error=>{console.log(error);})
    //this.currentUser$.pipe(tap(res=>this.id=res?.userId))
    // this.getproducts();
     console.log(this.id);
  }
  getproducts()
  {
    
    return this.sellerService.getProducts().subscribe(resp=>{this.products=resp;},error=>{console.log(error);})
  }
      
    // this.getUser();
  
    
    
  // }
  // getUser()
  // {
  //   this.currentUser$.subscribe
  //   (
  //     response=>{this.id=response?.userId;},
  //     error=>{console.log(error);}
  //   )
  //   return this.sellerService.getUser(this.id).subscribe(
  //     response=>{this.appUser=response;},
  //     error=>{console.log(error);}
      
  //   )
  // }

}
