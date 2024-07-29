import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SessionService } from '../session/session.service';
import { GET_USER_ID, HAS_ROLE, LOGIN, REGISTER, REGISTER_LIBRARIAN, REGISTER_PUBLIC } from '../../constants/server-constants';
import { SnackBarService } from '../snackbar/snackbar.service';
import { IdentityLogin } from '../../models/IdentityLogin';
import { Router } from '@angular/router';
import { Register } from '../../models/Register';
import { LIBRARIAN, PUBLIC } from '../../constants/role-constants';
import { concatMap, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {

  constructor(sessionService: SessionService, private httpClient: HttpClient, private snackBarService: SnackBarService, private router: Router) {
    super(sessionService)
   }

   Authenticate(username: string, password: string) {
    this.httpClient.post<IdentityLogin>(LOGIN, { 'email': username, 'password': password }, {headers: this.buildHeaders()})
    .pipe(
      concatMap(val => {
        console.log("logged in...");
        this.sessionService.setToken(val.accessToken);
        this.sessionService.setExpire(val.expiresIn.toString());
        return this.getUserId(username);
      }),
      concatMap(val => {
        console.log("getting userid..." + val);
        this.sessionService.setUserId(val);
        return this.hasRole(LIBRARIAN);
      }),
      concatMap(val => {
        this.sessionService.setLibrarian(val);
        return this.router.navigate(['/home']);
      })
    ).subscribe({
      error: (err) => {
            this.snackBarService.openSnackBar("We are unable to find an account with that email or password. Please try again.", "Ok");
      }
    });
   }

   register(registrant: Register) {
    this.httpClient.post<boolean>(REGISTER, registrant, {headers: this.buildHeaders()})
    .subscribe({
      next: (res) => {
        this.snackBarService.openSnackBar("Successfully Registered, please log in!", "Ok");
        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.log(err);
        this.snackBarService.openSnackBar("There was a problem creating your account: " + err.message, "Ok");
        this.router.navigate(['/register']);
      }
    });
   }

   hasRole(role: string) {
    return this.httpClient.post<boolean>(`${HAS_ROLE}${this.sessionService.getUserId()}/${role}`, null, {headers: this.buildHeaders()});
   }

   registerUserRole(id: string, role: string){
    return this.httpClient.post<boolean>(`${role == PUBLIC ? REGISTER_PUBLIC : REGISTER_LIBRARIAN}${this.sessionService.getUserId()}/`, null, {headers: this.buildHeaders()});
   }

   getUserId(username: string){
    return this.httpClient.post<string>(`${GET_USER_ID}${username}`, null, {headers: this.buildHeaders()});
   }
}
