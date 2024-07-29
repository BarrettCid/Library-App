import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  constructor() { }

  setToken(token: string) {
    localStorage.setItem('token', token);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  setUserId(id: string){
    localStorage.setItem('Id', id);
  }

  getUserId() {
    return localStorage.getItem('Id');
  }

  setExpire(expire: string){
    localStorage.setItem('expire', expire);
  }

  getExpire(){
    return localStorage.getItem('expire');
  }

  setLibrarian(val: boolean) {
    localStorage.setItem('Librarian', val.toString());
  }

  isLibrarian(){
    return localStorage.getItem('Librarian') == "true";
  }

  isLoggedIn(){
    if(this.getToken() == undefined || this.getUserId() == undefined)
    {
      return false;
    }
    return true;
  }

  clearSession(){
    localStorage.removeItem('token');
    localStorage.removeItem('Id');
    localStorage.removeItem('expire');
    localStorage.removeItem('Librarian');
  }
}
