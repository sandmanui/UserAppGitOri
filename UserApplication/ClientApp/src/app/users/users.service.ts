import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Settings} from '../shared/settings/settings.service';
import { User } from './user';
import { retry, catchError} from 'rxjs/operators';
import {_throw} from 'rxjs/observable/throw';

@Injectable()
export class UserService{

    constructor(private _settings: Settings,private _http: HttpClient){
    }

    getUsers(){
        //var effectUrl = this._settings.getApiUrl()+'/api/users';
        //console.log('effect Url ' + effectUrl);
        return this._http.get<User[]>(this._settings.getApiUrl()+'/api/users').pipe(
           // retry(2),
            catchError((error)=> {
                console.log('error from service');
                return _throw(error);
            })
        );
        
    }
}