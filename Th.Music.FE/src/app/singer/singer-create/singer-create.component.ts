import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { SingerModel } from 'src/app/shared/models/singer-model';
import { SingerService } from 'src/app/shared/services/singer.service';
import { Router } from '@angular/router';
import { LoaderService } from 'src/app/shared/services/loader.service';

@Component({
  selector: 'app-singer-create',
  templateUrl: './singer-create.component.html',
  styleUrls: ['./singer-create.component.scss']
})
export class SingerCreateComponent implements OnInit {

  model = new SingerModel();
  errors = [];

  @ViewChild('avatarInput', { static: false }) avatarInput: ElementRef;
  
  constructor(
    private _router: Router,
    private _loaderService: LoaderService,
    private _singerService: SingerService
  ) { }

  ngOnInit() { }

  create() {
    this._loaderService.show();
    let fileBrowser = this.avatarInput.nativeElement;
    const formData = new FormData();
    formData.append('avatar', fileBrowser.files[0]);
    formData.append('name', !this.model.name ? '' : this.model.name);

    this._singerService.create(formData)
      .then(result => {
        if (result.succeed) {
          alert('Create singer successfully!');
          this._router.navigate(['/song/create']);
        }
        else {
          this.errors = [];
          result.errors.forEach(e => {
            this.errors.push(e);
          });
        }
        this._loaderService.hide();
      })
      .catch(e => {
        this._loaderService.hide();
      })
  }
}
