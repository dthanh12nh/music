import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SongModel } from '../models/song-model';
import { Observable } from 'rxjs';
import { Apis } from '../constants/apis';

@Injectable({
  providedIn: 'root'
})
export class SongService {

  constructor(private http: HttpClient) { }

  create(data: FormData) : Observable<SongModel> {
    let url = 'http://localhost:2019/songs'
    return this.http.post<SongModel>(url, data);
  }

  search(title: string): Observable<SongModel[]> {
    let data = {
      title: title
    };

    return this.http.get<SongModel[]>(Apis.SONGS_SEARCHING, { params: data });
  }
}
