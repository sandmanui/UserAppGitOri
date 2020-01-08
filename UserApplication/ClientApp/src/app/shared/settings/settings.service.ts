import { Injectable, Injector } from '@angular/core';

@Injectable()
export class Settings{
    private apiUrl: string;

getApiUrl(): string {
    this.apiUrl= "https://localhost:44399";
    console.log('this is hosturl ' + this.apiUrl);
    return this.apiUrl;
  }

}