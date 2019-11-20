import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConstituencyAddEditComponent } from './constituency-add-edit.component';

describe('ConstituencyAddEditComponent', () => {
  let component: ConstituencyAddEditComponent;
  let fixture: ComponentFixture<ConstituencyAddEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConstituencyAddEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConstituencyAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
