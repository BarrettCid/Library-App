import { Component } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  
  formGroup!: UntypedFormGroup;

  constructor(private _fb: UntypedFormBuilder, private authService: AuthService){}

  ngOnInit(): void {
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
