import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { SongService } from 'src/app/shared/services/song.service';
import { SongModel } from '../../shared/models/song-model';

@Component({
  selector: 'app-song-create',
  templateUrl: './song-create.component.html',
  styleUrls: ['./song-create.component.scss']
})
export class SongCreateComponent implements OnInit {
  public song: SongModel;

  @ViewChild('fileInput', { static: false }) fileInput: ElementRef;

  constructor(
    private _songService : SongService
  ) {
    this.song = new SongModel();
  }

  ngOnInit() {}

  public createSong(song: SongModel) : void {
    let fileBrowser = this.fileInput.nativeElement;
    if (fileBrowser.files && fileBrowser.files[0]) {
      const formData = new FormData();
      formData.append('file', fileBrowser.files[0]);
      formData.append('title', song.title);

      this._songService.create(formData)
        .subscribe(s => {
          alert('Successfully!');
        })
    }
  }
}
