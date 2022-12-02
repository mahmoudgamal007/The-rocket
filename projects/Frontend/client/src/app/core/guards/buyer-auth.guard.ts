import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { AccountService } from 'src/app/account/account.service';
import { observable, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class BuyerAuthGuard implements CanActivate {
  constructor(private router: Router, private accountService: AccountService, private toastrService: ToastrService) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map(auth => {
        if (auth?.accountType === 'Buyer') {
          console.log('buyer');
          return true;
        } else if (auth?.accountType !== 'Buyer' && auth?.accountType !== 'Seller' && auth?.accountType !== 'Admin') {
          console.log('annonymous');
          this.router.navigate(['account/login'], { queryParams: { returnUrl: state.url } });
          this.toastrService.info('Need to log in as Buyer to access this page', 'Account');
          return false;
        } else {
          console.log('Seller or Admin');
          this.router.navigate(['/product']);
          this.toastrService.warning('Access denied, need to log in with a buyer account instead', 'Access Denied');
          return false;
        }
      })
    );
  }
}
