import { Injectable } from '@angular/core';
import { UserModel } from '../models/authentication/user-model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { RegisterModel } from '../models/authentication/register-model';
import { ResponseModel } from '../models/response-model';
import { Apis } from '../constants/apis';
import { LoginModel } from '../models/authentication/login-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private http: HttpClient
  ) { }

  register(model: RegisterModel) : Promise<ResponseModel<UserModel>> {
    return this.http
      .post<ResponseModel<UserModel>>(Apis.USERS_REGISTER, model)
      .toPromise();
  }

  login(model: LoginModel): Promise<ResponseModel<UserModel>> {
    return this.http
      .post<ResponseModel<UserModel>>(Apis.USERS_LOGIN, model)
      .toPromise();
  }
}
