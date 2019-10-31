import { SingerModel } from './singer-model';

export class SongModel {
    id: string;
    title: string;
    file: File;
    fileUrl: string;
    avatar: File;
    avatarUrl: string;
    albumId: string;
    singerId: string;
    singer: SingerModel;
}
