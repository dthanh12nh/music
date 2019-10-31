import { SingerModel } from './singer-model';

export class AlbumModel {
    id: string;
    name: string;
    avatar: File;
    singerId: string;
    singer: SingerModel;
}