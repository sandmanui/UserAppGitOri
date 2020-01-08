import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersComponent } from './users.component';
import {UserDetailComponent} from '../user-detail/user-detail.component';
import {UserService} from './users.service';
import {Settings} from '../shared/settings/settings.service';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';

describe('UsersComponent', () => {
  let component: UsersComponent;
  let fixture: ComponentFixture<UsersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsersComponent, UserDetailComponent ],
      imports: [HttpClientModule],
      providers: [UserService,Settings]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  //test to check component created successfully or not
  it('should create successfully', () => {
    expect(component).toBeTruthy();
  });

  //test to check elements on page with correct value
  it('should display a title', () => {
      const title = fixture.nativeElement.querySelector('h2').textContent;
      expect(title).toEqual('Users List');
  });
});
