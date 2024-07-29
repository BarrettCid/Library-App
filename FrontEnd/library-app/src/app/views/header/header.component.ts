import { Component, Input, OnInit } from '@angular/core';
import {Router} from "@angular/router"
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { SessionService } from 'src/app/shared/services/session/session.service';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { LIBRARIAN } from 'src/app/shared/constants/role-constants';
import { SnackBarService } from 'src/app/shared/services/snackbar/snackbar.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {

  hasLibrarianRole: boolean = false;

  constructor(private router: Router, private sessionService: SessionService, private authService: AuthService, private snackBarService: SnackBarService) {}

  ngOnInit(): void {

  }

  isLibrarian() {
    return this.sessionService.isLibrarian();
  }

  isLoggedIn() {
    return this.sessionService.isLoggedIn();
  }

  signOut() {
    this.sessionService.clearSession();
    this.router.navigate(['/welcome']);
  }

  navigateSignIn() {
    this.router.navigate(['/login']);
  }

  navigateBookSearch(){
    this.router.navigate(['/book-search']);
  }

  navigateRegister(){
    this.router.navigate(['/register']);
  }

  navigateHome() {
    this.router.navigate(['/home']);
  }

  navigateAddBook() {
    this.router.navigate(['manage-book', 0]);
  }
}
