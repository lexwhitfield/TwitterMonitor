import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConstituenciesComponent } from './constituencies.component';

describe('ConstituenciesComponent', () => {
  let component: ConstituenciesComponent;
  let fixture: ComponentFixture<ConstituenciesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConstituenciesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConstituenciesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
