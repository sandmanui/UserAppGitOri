import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpErrorResponse } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { UsersComponent } from './users/users.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import {UserService} from './users/users.service';

//shared component
import {Settings} from '../app/shared/settings/settings.service';
import { PaginationComponent } from './pagination/pagination.component';

//translation
import {TranslateService} from './translate/translate.service';
import {TranslatePipe} from './translate/translate.pipe';
import {TRANSLATION_PROVIDERS} from './translate/translation';
import { ProductComponent } from './product/product.component';
import { StockStatusComponent } from './stockstatus/stockstatus.component';
import { AlbumComponent } from './album/album.component';

import { ReactiveFormsModule } from '@angular/forms';
import { FieldErrorDisplayComponent } from './field-error-display/field-error-display.component';

import {HttpErrorInterceptor} from './http-error.interceptor.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    UsersComponent,
    UserDetailComponent,
    PaginationComponent,
    TranslatePipe,
    ProductComponent,
    StockStatusComponent,
    AlbumComponent,
    FieldErrorDisplayComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: UsersComponent, pathMatch: 'full' },
      {path: 'users', component:UsersComponent},
      {path: 'products', component: ProductComponent},
      {path: 'albums', component: AlbumComponent}
    ])
  ],
  providers: [Settings,UserService,[TRANSLATION_PROVIDERS,TranslateService],{provide:HTTP_INTERCEPTORS,useClass:HttpErrorInterceptor,multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
