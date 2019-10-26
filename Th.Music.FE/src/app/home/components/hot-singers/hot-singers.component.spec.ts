import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HotSingersComponent } from './hot-singers.component';

describe('HotSingersComponent', () => {
  let component: HotSingersComponent;
  let fixture: ComponentFixture<HotSingersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HotSingersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HotSingersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
