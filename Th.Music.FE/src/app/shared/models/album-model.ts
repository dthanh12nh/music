import { SingerModel } from './singer-model';

export class AlbumModel {
    id: string;
    name: string;
    image: File;
    singer: SingerModel;
}