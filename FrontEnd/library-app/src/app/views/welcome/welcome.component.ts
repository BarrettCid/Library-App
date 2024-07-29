import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { SessionService } from 'src/app/shared/services/session/session.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrl: './welcome.component.css'
})
export class WelcomeComponent implements OnInit {

  formGroup!: UntypedFormGroup;

  constructor(private _snackBar: MatSnackBar, private _fb: UntypedFormBuilder, private authService: AuthService, private sessionService: SessionService, private router: Router) { }
  
  ngOnInit(): void {
    if( this.sessionService.isLoggedIn()) {
      this.router.navigate(['/home']);
    }
    this.formGroup = this._fb.group({
      username: [null, Validators.required],
      password: [null, Validators.required],
    });
  }

  login() {
    let username = this.formGroup.controls['username'].value;
    let password = this.formGroup.controls['password'].value;
    this.authService.Authenticate(username, password);
  }
}
