import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PartyAddEditComponent } from './party-add-edit.component';

describe('PartyAddEditComponent', () => {
  let component: PartyAddEditComponent;
  let fixture: ComponentFixture<PartyAddEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PartyAddEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PartyAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
