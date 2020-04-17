import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  showAuthenticationMenu = false;
  showRegisterPopup = false;

  constructor() { }

  ngOnInit() {
  }

  toggleAuthenticationMenu(): void {
    this.showAuthenticationMenu = !this.showAuthenticationMenu;
  }

  toggleRegisterPopup() {
    this.showRegisterPopup = !this.showRegisterPopup;
  }

}
