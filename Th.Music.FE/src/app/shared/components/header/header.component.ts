import { Component, OnInit } from '@angular/core';
import { SongService } from '../../services/song.service';
import { Router } from '@angular/router';
import { UserModel } from '../../models/authentication/user-model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  searchText: string;
  user: UserModel;

  constructor(
    private _songService: SongService,
    private _router: Router
  ) { 
    let stringUser = localStorage.getItem('user');
    this.user = !stringUser ? null : JSON.parse(stringUser);
  }

  ngOnInit() {
  }

  searchKeyPress(event: KeyboardEvent) {
    
    //not enter key
    if (event.keyCode !== 13) {
      return;
    }

    this._router.navigate(['/searching'], { queryParams: { title: this.searchText } });
  }

  navigate(name: string) {
    switch(name) {
      case 'upload':
        this._router.navigate(['/song/create']);
        break;
    }
  }

  logout() {
    if(confirm('Would you like to log out?')) {
      localStorage.removeItem('user');
      this._router.navigate(['/']);
      this.user = null;
    }
  }
}
