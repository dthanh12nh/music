//modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from "@angular/material/button";
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatInputModule } from '@angular/material/input';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { OverlayModule } from '@angular/cdk/overlay';
import { SlideshowModule } from 'ng-simple-slideshow';

//components
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { HeaderComponent } from './components/header/header.component';
import { BannerComponent } from './home/components/banner/banner.component';
import { RankComponent } from './home/components/rank/rank.component';
import { HotAlbumsComponent } from './home/components/hot-albums/hot-albums.component';
import { FooterComponent } from './components/footer/footer.component';
import { SongCreateComponent } from './song/song-create/song-create.component';
import { UserCreateComponent } from './user/user-create/user-create.component';
import { PlayingComponent } from './playing/playing.component';
import { SearchingComponent } from './searching/searching.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './register/register.component';
import { LoaderComponent } from './shared/components/loader/loader.component';
import { HotSingersComponent } from './home/components/hot-singers/hot-singers.component';
import { SingerCreateComponent } from './singer/singer-create/singer-create.component';
import { AlbumCreateComponent } from './album/album-create/album-create.component';

//services
import { SongService } from './shared/services/song.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    BannerComponent,
    RankComponent,
    HotAlbumsComponent,
    FooterComponent,
    SongCreateComponent,
    PlayingComponent,
    SearchingComponent,
    UserCreateComponent,
    LoginComponent,
    RegisterComponent,
    LoaderComponent,
    HotSingersComponent,
    SingerCreateComponent,
    AlbumCreateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatSliderModule,
    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatInputModule,
    MatSidenavModule,
    MatListModule,
    MatCardModule,
    MatMenuModule,
    MatSelectModule,
    MatProgressSpinnerModule,
    OverlayModule,
    SlideshowModule
  ],
  entryComponents: [
    LoaderComponent
  ],
  providers: [SongService],
  bootstrap: [AppComponent]
})
export class AppModule { }
