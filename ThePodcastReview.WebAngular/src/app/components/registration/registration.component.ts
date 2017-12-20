import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  private _registerForm: FormGroup;

  constructor(private _form: FormBuilder, private _authService: AuthService) { 
    this.createForm();
    console.log("Constructor:", this._registerForm.value);
  }

  ngOnInit() {
    console.log("ngOnInit", this._registerForm.value);
  }

  createForm(){
    this._registerForm = this._form.group({
      email: new FormControl('', Validators.min(5)),
      password: new FormControl('', Validators.min(10)),
      confirmPassword: new FormControl
    });
    console.log("createForm:", this._registerForm.value);
  }

  onSubmit(){
    console.log(this._registerForm.value);
    this._authService
      .register(this._registerForm.value)
      .subscribe( () => this._authService.login(this._registerForm.value));
  }
}