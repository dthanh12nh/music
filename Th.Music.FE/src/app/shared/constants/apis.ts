export class Apis {
    private static readonly server = 'http://localhost:2019';

    static readonly USERS_REGISTER = `${Apis.server}/users/register`;
    static readonly USERS_LOGIN = `${Apis.server}/users/login`;
    static readonly SONGS_SEARCHING = `${Apis.server}/songs/searching`;
    static readonly SONGS = `${Apis.server}/songs`;
    static readonly SINGERS = `${Apis.server}/singers`;
    static readonly SINGERS_ALBUMS = `${Apis.server}/singers/{0}/albums`;
    static readonly ALBUMS = `${Apis.server}/albums`;
}