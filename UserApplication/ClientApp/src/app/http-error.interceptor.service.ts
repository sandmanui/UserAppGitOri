import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { catchError } from 'rxjs/operators';
import { RouterInitializer } from '@angular/router/src/router_module';
import { _throw } from 'rxjs/observable/throw';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor{

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    //throw new Error("Method not implemented.");
    return next.handle(req).pipe(
      catchError((error:HttpErrorResponse)=>{
        console.log('error from interceptor tp');
        return _throw('sandman123');
      })
    );
  }

  constructor() { }

}
