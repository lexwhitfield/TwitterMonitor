import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TwitteruserComponent } from './twitteruser.component';

describe('TwitteruserComponent', () => {
  let component: TwitteruserComponent;
  let fixture: ComponentFixture<TwitteruserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TwitteruserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TwitteruserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
