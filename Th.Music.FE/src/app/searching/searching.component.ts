import { Component, OnInit } from '@angular/core';
import { SongService } from 'src/app/shared/services/song.service';
import { SongModel } from '../shared/models/song-model';
import { ActivatedRoute } from '@angular/router';
import { LoaderService } from '../shared/services/loader.service';

@Component({
  selector: 'app-searching',
  templateUrl: './searching.component.html',
  styleUrls: ['./searching.component.scss']
})
export class SearchingComponent implements OnInit {

  songs: SongModel[];

  constructor(
    private _songService: SongService,
    private _activatedRoute: ActivatedRoute,
    private _loaderService: LoaderService
  ) { }

  ngOnInit() {
    this._loaderService.show();
    this._activatedRoute.queryParams.subscribe(p => {
      this._songService.search(p.title)
        .then(songs => {
          this.songs = songs;
          this._loaderService.hide();
        }).catch(e => {
          this._loaderService.hide();
        });
    });
  }
}
