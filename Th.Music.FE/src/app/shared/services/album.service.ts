import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AlbumModel } from '../models/album-model';
import { Apis } from '../constants/apis';
import { ResponseModel } from '../models/response-model';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {

  constructor(
    private http: HttpClient
  ) { }

  getAll(): Promise<AlbumModel[]> {
    return this.http
      .get<AlbumModel[]>(Apis.ALBUMS)
      .toPromise();
  }

  create(formData: FormData): Promise<ResponseModel<AlbumModel>> {
    let user = JSON.parse(localStorage.getItem('user'));
    let token = user.token;

    return this.http
      .post<ResponseModel<AlbumModel>>(Apis.ALBUMS, formData, {
        headers: new HttpHeaders({
          'Authorization': 'Bearer ' + token
        })
      })
      .toPromise();
  }
}
