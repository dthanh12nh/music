import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SongModel } from '../shared/models/song-model';
import { SongService } from '../shared/services/song.service';
import { LoaderService } from '../shared/services/loader.service';

@Component({
  selector: 'app-playing',
  templateUrl: './playing.component.html',
  styleUrls: ['./playing.component.scss']
})
export class PlayingComponent implements OnInit {

  song = new SongModel();

  constructor(
    private _loaderService: LoaderService,
    private _activatedRoute: ActivatedRoute,
    private _songService: SongService,
  ) { 
    this.song.fileUrl = null;
    this._loaderService.show();
    this._activatedRoute.params.subscribe(p => {
      let id = p['id'];
      this._songService.getById(id)
        .then(s => {
          this.song = s;
          this._loaderService.hide();
        })
        .catch(e => {
          this._loaderService.hide();
        });
    });
  }

  ngOnInit() {
    
  }
}
