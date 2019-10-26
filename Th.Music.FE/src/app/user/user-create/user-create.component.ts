import { Component, OnInit } from '@angular/core';
import { UserModel } from '../../shared/models/authentication/user-model';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.scss']
})
export class UserCreateComponent implements OnInit {
  user: UserModel;

  constructor(
    private userService: UserService
  ) { }

  ngOnInit() {
  }

  create(user: UserModel) {
    
  }
}
