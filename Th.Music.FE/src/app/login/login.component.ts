import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../shared/models/authentication/login-model';
import { UserService } from '../shared/services/user.service';
import { LoaderService } from '../shared/services/loader.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  model = new LoginModel();
  errors = [];

  constructor(
    private _userService: UserService,
    private _loaderService: LoaderService,
    private _router: Router,
  ) { }

  ngOnInit() { }
  
  login(model: LoginModel) {
    this._loaderService.show();

    this._userService.login(model)
    .then(result => {
      if (result.succeed) {
        alert(result.message);
        localStorage.setItem('user', JSON.stringify(result.data));
        this._router.navigate(['/']);
      }
      else {
        this.errors = [];
        result.errors.forEach(e => {
          this.errors.push(e);
        });
      }
      this._loaderService.hide();
    })
    .catch(p => {
      this._loaderService.hide();
    });
  }
}
