import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SongModel } from '../models/song-model';
import { Observable } from 'rxjs';
import { Apis } from '../constants/apis';
import { ResponseModel } from '../models/response-model';

@Injectable({
  providedIn: 'root'
})
export class SongService {

  constructor(private http: HttpClient) { }

  getById(id: string) : Promise<SongModel>{
    return this.http
      .get<SongModel>(`${Apis.SONGS}/${id}`)
      .toPromise();
  }

  create(data: FormData) : Promise<ResponseModel<SongModel>> {
    let user = JSON.parse(localStorage.getItem('user'));
    let token = user.token;
    
    return this.http
      .post<ResponseModel<SongModel>>(Apis.SONGS, data, {
        headers: new HttpHeaders({
          'Authorization': 'Bearer ' + token
        })
      })
      .toPromise();
  }

  search(title: string): Promise<SongModel[]> {
    let data = {
      title: title
    };

    return this.http
      .get<SongModel[]>(Apis.SONGS_SEARCHING, { params: data })
      .toPromise();
  }
}
