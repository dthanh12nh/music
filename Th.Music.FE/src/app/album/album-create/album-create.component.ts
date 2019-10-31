import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { AlbumModel } from 'src/app/shared/models/album-model';
import { SingerModel } from 'src/app/shared/models/singer-model';
import { SingerService } from 'src/app/shared/services/singer.service';
import { LoaderService } from 'src/app/shared/services/loader.service';
import { AlbumService } from 'src/app/shared/services/album.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-album-create',
  templateUrl: './album-create.component.html',
  styleUrls: ['./album-create.component.scss']
})
export class AlbumCreateComponent implements OnInit {

  model = new AlbumModel();
  allSingers: SingerModel[];
  errors = [];

  @ViewChild('avatarInput', { static: false }) avatarInput: ElementRef;

  constructor(
    private _router: Router,
    private _loaderService: LoaderService,
    private _singerService: SingerService,
    private _albumService: AlbumService
  ) {
    this._singerService.getAll()
      .then(singers => {
        this.allSingers = singers;
      });
  }

  ngOnInit() {
  }

  create() {
    this._loaderService.show();
    let fileBrowser = this.avatarInput.nativeElement;
    const formData = new FormData();
    formData.append('avatar', fileBrowser.files.length > 0 ? fileBrowser.files[0] : '');
    formData.append('name', !this.model.name ? '' : this.model.name);
    formData.append('singerId', !this.model.singerId ? '' : this.model.singerId);

    this._albumService.create(formData)
      .then(result => {
        if (result.succeed) {
          alert(result.message);
          this._router.navigate(['/song/create']);
        }
        else {
          this.errors = [];
          result.errors.forEach(e => {
            this.errors.push(e);
          });
        }
        this._loaderService.hide();
      })
      .catch(e => {
        this.errors = [];
        this.errors.push(e.message);
        this._loaderService.hide();
      })
  }

}
