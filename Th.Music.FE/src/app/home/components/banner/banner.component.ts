import { Component, OnInit } from '@angular/core';
import { IImage } from 'ng-simple-slideshow';
import { Router } from '@angular/router';

@Component({
  selector: 'app-banner',
  templateUrl: './banner.component.html',
  styleUrls: ['./banner.component.scss']
})
export class BannerComponent implements OnInit {

  imageUrls: IImage[] = [];

  constructor(
    private _router: Router
  ) {

    let urls : IImage[] = [
      { url: './assets/images/Di_Du_Dua_Di-Bich_Phuong.jpg', clickAction: () => this.clickBanner(0) },
      { url: './assets/images/Cham_Khe_Tim_Anh_Mot_Chut_Thoi.jpg', clickAction: () => this.clickBanner(1) },
      { url: './assets/images/Het_Thuong_Can_Nho.jpg', clickAction: () => this.clickBanner(2) }
    ];

    urls.forEach(u => {
      this.imageUrls.push(u);
    });
  }

  ngOnInit() {
  }

  clickBanner(index: number) {

    switch (index) {

      case 0:
        this._router.navigate(['/playing', 'E5163BDD-89E7-4A89-87A3-08D75C1122A1']);
        break;

        case 1:
          this._router.navigate(['/playing', '2332D0A1-458F-409D-6800-08D762C0E1C1']);
          break;

        case 2:
          this._router.navigate(['/playing', 'D79AD8E3-7368-4296-6801-08D762C0E1C1']);
          break;
    }
  }
}
