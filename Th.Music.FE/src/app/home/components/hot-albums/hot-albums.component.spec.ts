import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HotAlbumsComponent } from './hot-albums.component';

describe('HotAlbumsComponent', () => {
  let component: HotAlbumsComponent;
  let fixture: ComponentFixture<HotAlbumsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HotAlbumsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HotAlbumsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
