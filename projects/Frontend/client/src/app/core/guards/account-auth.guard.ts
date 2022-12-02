import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { AccountService } from 'src/app/account/account.service';
import { observable, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { EventListener } from 'ngx-bootstrap/utils/facade/browser';

@Injectable({
  providedIn: 'root'
})
export class AccountAuthGuard implements CanActivate {
  constructor(private router: Router, private accountService: AccountService, private toastrService: ToastrService) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map(auth => {
        if (!auth) {
          return true;
        } else {
          this.router.navigate(['/product']);
          this.toastrService.info('Already Logged In');
          return false;
        }
      })
    );
  }
}
