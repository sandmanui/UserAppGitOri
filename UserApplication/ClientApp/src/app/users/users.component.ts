import { Component, OnInit } from '@angular/core';
import {User} from './user';
//import {Users} from './mock-users';
import {UserService} from './users.service';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import {catchError} from 'rxjs/operators/catchError'; 
import { of } from 'rxjs/observable/of';
import {TranslateService} from '../translate/translate.service';

import {TranslatePipe } from '../translate/translate.pipe';


@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  selectedUser: User;
  public userObs$: Observable<User[]>;
  loadingError$ = new Subject<boolean>();
  public errorObject: Object = null;
  isviewTable:boolean = false;

  pageResults: Array<User>;
  clientSearchResult: Array<User>;
  
  constructor(private _userService: UserService,private _translate: TranslateService) { }

  ngOnInit() {
    /*this._userService.getUsers().subscribe(result=>{
      this.users = result;
    },error=> console.log(error));*/
    this._translate.use('en');

    //attached pipe for error handling and making error object with error value to make error div visible
    this.userObs$ = this._userService.getUsers().pipe(
      catchError((error)=>{
        //console.error('error loading list of users', error);
        console.log(error);
        this.loadingError$.next(true);
        this.errorObject = error;
        return of();
      })
    );
  }

  onSelect(user: User): void{
    this.selectedUser=user;
  }

  showTable(): void{
    this.pageResults = new Array<User>();
    this._userService.getUsers().subscribe(result=>{
      this.pageResults = result;
      this.clientSearchResult = result;
      this.isviewTable = true;
    },error=> console.log(error.message + 'ttt'));
  }

  getPageResult(event: any) {
    setTimeout(() => this.pageResults = event, 0);
  }

}


