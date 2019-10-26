import { Component, OnInit } from '@angular/core';
import { RegisterModel } from '../shared/models/authentication/register-model';
import { UserService } from '../shared/services/user.service';
import { Router } from '@angular/router';
import { LoaderService } from '../shared/services/loader.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  model = new RegisterModel();
  errors = [];

  constructor(
    private _userService: UserService,
    private _loaderService: LoaderService,
    private _router: Router
  ) { }

  ngOnInit() { }

  register(model: RegisterModel) {
    this._loaderService.show();
    this._userService.register(model).then(result => {
      if (result.succeed) {
        alert(result.message);
        this._router.navigate(['/login']);
      }
      else {
        this.errors = [];
        result.errors.forEach(e => {
          this.errors.push(e);
        });
      }
      this._loaderService.hide();
    }).catch(error => {
      this._loaderService.hide();
      return error;
    });
  }
}
