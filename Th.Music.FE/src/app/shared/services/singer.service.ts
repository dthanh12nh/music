import { Injectable } from '@angular/core';
import { SingerModel } from '../models/singer-model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Apis } from '../constants/apis';
import { ResponseModel } from '../models/response-model';
import { UserModel } from '../models/authentication/user-model';
import { AlbumModel } from '../models/album-model';

@Injectable({
  providedIn: 'root'
})
export class SingerService {

  constructor(
    private http: HttpClient
  ) { }

  getAll(): Promise<SingerModel[]> {
    return this.http
      .get<SingerModel[]>(Apis.SINGERS)
      .toPromise();
  }

  getAlbums(singerId: string): Promise<AlbumModel[]> {
    return this.http
      .get<AlbumModel[]>(Apis.SINGERS_ALBUMS.replace('{0}', singerId))
      .toPromise();
  }

  create(formData: FormData): Promise<ResponseModel<SingerModel>> {
    let user = JSON.parse(localStorage.getItem('user'));
    let token = user.token;

    return this.http
      .post<ResponseModel<SingerModel>>(Apis.SINGERS, formData, {
        headers: new HttpHeaders({
          'Authorization': 'Bearer ' + token
        })
      })
      .toPromise();
  }
}
