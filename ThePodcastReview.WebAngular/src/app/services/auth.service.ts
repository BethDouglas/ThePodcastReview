import { Injectable } from '@angular/core';
import { RegisterUser } from '../models/REgisterUser';
import { HttpClient } from '@angular/common/http';
import { Token } from '@angular/compiler';

const Api_Url = 'http://localhost:60311';

@Injectable()
export class AuthService {


  constructor( private _http: HttpClient) { }

  register(regUserData: RegisterUser){
    return this._http.post(`${Api_Url}/api/Account/Register`, regUserData);
  }

  login(loginInfo){
    const str = 
      `grant_type=password&username=${encodeURI(loginInfo.email)}&password=${encodeURI(loginInfo.password)}`;

    return this._http.post(`${Api_Url}/token`, str).subscribe((token: Token) => {
      localStorage.setItem('id_token', token.access_token);
      console.log(token.access_token);
    });

  }

}
