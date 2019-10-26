import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SingerCreateComponent } from './singer-create.component';

describe('SingerCreateComponent', () => {
  let component: SingerCreateComponent;
  let fixture: ComponentFixture<SingerCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SingerCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SingerCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
