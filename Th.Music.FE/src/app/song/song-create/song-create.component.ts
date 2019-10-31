import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { SongService } from 'src/app/shared/services/song.service';
import { SongModel } from '../../shared/models/song-model';
import { SingerService } from 'src/app/shared/services/singer.service';
import { SingerModel } from 'src/app/shared/models/singer-model';
import { AlbumModel } from 'src/app/shared/models/album-model';
import { Router } from '@angular/router';
import { LoaderService } from 'src/app/shared/services/loader.service';

@Component({
  selector: 'app-song-create',
  templateUrl: './song-create.component.html',
  styleUrls: ['./song-create.component.scss']
})
export class SongCreateComponent implements OnInit {
  
  song: SongModel;
  allSingers: SingerModel[];
  albums: AlbumModel[];
  isDisableAlbum = true;
  errors = [];

  @ViewChild('fileInput', { static: false }) fileInput: ElementRef;
  @ViewChild('avatarInput', { static: false }) avatarInput: ElementRef;

  constructor(
    private _router: Router,
    private _loaderService: LoaderService,
    private _songService : SongService,
    private _singerService: SingerService,
  ) {
    this.song = new SongModel();
    this._singerService.getAll()
      .then(singers => {
        this.allSingers = singers;
      });
    this.albums = [];
  }

  ngOnInit() {}

  public createSong() {
    this._loaderService.show();
    let fileBrowser = this.fileInput.nativeElement;
    let avatarBrowser = this.avatarInput.nativeElement;

    const formData = new FormData();
    formData.append('title', !this.song.title ? '' : this.song.title);
    formData.append('singerId', !this.song.singerId ? '' : this.song.singerId);
    formData.append('albumId', !this.song.albumId ? '' : this.song.albumId);
    formData.append('file', fileBrowser.files.length > 0 ? fileBrowser.files[0] : '');
    formData.append('avatar', avatarBrowser.files.length > 0 ? avatarBrowser.files[0] : '');

    this._songService.create(formData)
    .then(result => {
      this._loaderService.hide();
      if (result.succeed) {
        alert(result.message);
        this._router.navigate(['/']);
      }
      else {
        this.errors = [];
        result.errors.forEach(e => {
          this.errors.push(e);
        });
      }
    })
    .catch(e => {
      this.errors = [];
      this.errors.push(e.message);
      this._loaderService.hide();
    })
  }

  onChangeSinger(singerId: string) {
    this._singerService
      .getAlbums(singerId)
      .then(result => {
        this.albums = result;
        this.isDisableAlbum = false;
      })
  }
}
