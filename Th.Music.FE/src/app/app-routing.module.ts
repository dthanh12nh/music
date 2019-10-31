import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SongCreateComponent } from './song/song-create/song-create.component';
import { PlayingComponent } from './playing/playing.component';
import { SearchingComponent } from './searching/searching.component';
import { UserCreateComponent } from './user/user-create/user-create.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { SingerCreateComponent } from './singer/singer-create/singer-create.component';
import { AlbumCreateComponent } from './album/album-create/album-create.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'song/create', component: SongCreateComponent },
  { path: 'playing/:id', component: PlayingComponent },
  { path: 'searching', component: SearchingComponent },
  { path: 'user/create', component: UserCreateComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'singer/create', component: SingerCreateComponent },
  { path: 'album/create', component: AlbumCreateComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
