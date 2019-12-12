import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TwitterusersComponent } from './twitterusers.component';

describe('TwitterusersComponent', () => {
  let component: TwitterusersComponent;
  let fixture: ComponentFixture<TwitterusersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TwitterusersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TwitterusersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
