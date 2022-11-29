import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Subscription } from 'rxjs';
import { finalize, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AppUser } from '../shared/models/appUser';
import { IAppUser } from '../shared/models/IAppUser';
import { IUser } from '../shared/models/user';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.apiUrl;

  private currentUserSource = new BehaviorSubject<IUser | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  private currentAppUserSource = new BehaviorSubject<IAppUser | null>(null);
  currentAppUser$ = this.currentAppUserSource.asObservable();
  currentAppUserId?: string;

  constructor(private http: HttpClient, private router: Router) {}

  getCurrentUserValue() {
    return this.currentUserSource.value;
  }

  loadCurrentUser(token: string) {
    let headers = new HttpHeaders();
    headers.set('Authorization', `Bearer ${token}`);

    return this.http
      .get(this.baseUrl + 'account/GetUserByToken', { headers })
      .pipe(
        map((user: IUser | any) => {
          if (user) {
            localStorage.setItem('token', user.jwtToken);
            this.currentUserSource.next(user);
          }
        })
      );
  }

  login(values: any) {
    return this.http.post(this.baseUrl + 'account', values).pipe(
      map((user: IUser | any) => {
        if (user) {
          localStorage.setItem('userId', user.userId);
          localStorage.setItem('token', user.jwtToken);
          this.currentUserSource.next(user);
        }
      })
    );
  }

  register(appUser: AppUser) {
    console.log(appUser);
    return this.http.post(this.baseUrl + 'AppUser', appUser).pipe(
      map((user: IUser | any) => {
        if (user) {
          localStorage.setItem('token', user.jwtToken);
          this.currentUserSource.next(user);
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('userId');
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/product');
  }

  checkEmailExists(email: string) {
    return this.http.get(
      this.baseUrl + '/AppUser/CheckIfUserExistByEmail?email=' + email
    );
  }

  getCurrentUserId() {
    this.currentUser$.subscribe(
      (response) => {
        this.currentAppUserId = response?.userId;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getCurrentAppUser() {
    return this.http
      .get<IAppUser>(
        this.baseUrl +
          '/AppUser/GetAppUserByUserId?AppUserId=' +
          this.currentAppUserId
      )
      .pipe(
        map((AppUser: IAppUser | any) => {
          if (AppUser) {
            this.currentAppUserSource.next(AppUser);
          }
        })
      );
  }

  
}
