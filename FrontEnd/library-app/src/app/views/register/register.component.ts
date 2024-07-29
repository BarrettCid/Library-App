import { Component, OnInit } from '@angular/core';
import { AbstractControl, UntypedFormBuilder, UntypedFormGroup, ValidationErrors, Validators } from '@angular/forms';
import { LIBRARIAN, PUBLIC } from 'src/app/shared/constants/role-constants';
import { Register } from 'src/app/shared/models/Register';
import { AuthService } from 'src/app/shared/services/auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit{
  
  formGroup!: UntypedFormGroup;
  roles: string[] = [PUBLIC, LIBRARIAN];

  constructor(private _fb: UntypedFormBuilder, private authService: AuthService){}
  
  ngOnInit(): void {
    this.formGroup = this._fb.group({
      firstname: [null, Validators.required],
      lastname: [null, Validators.required],
      username: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required, Validators.pattern('((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{9,30})')]],
      confirmPassword: [null, Validators.required],
      selectedRole: [null, Validators.required]
    }, { validators: this.validatePasswordMatch });
  }

  validatePasswordMatch(
    control: AbstractControl
  ): ValidationErrors | null {
    if (control && control.get("password") && control.get("confirmPassword")) {
      const password = control.get("password")!.value;
      const confirmPassword = control.get("confirmPassword")!.value;  
      return (password != confirmPassword) ? { passwordMatchError: true } : null
    }
    return null;
  }

  register() {
    let registrant = new Register();
    registrant.firstName = this.formGroup.controls['firstname'].value;
    registrant.lastName = this.formGroup.controls['lastname'].value;
    registrant.email = this.formGroup.controls['username'].value;
    registrant.password = this.formGroup.controls['password'].value;
    registrant.role = this.formGroup.controls['selectedRole'].value;
    this.authService.register(registrant);
  }

}
