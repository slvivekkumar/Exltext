import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import {HttpClient, HttpClientModule} from '@angular/common/http'
import {BsDatepickerModule} from 'ngx-bootstrap/datepicker'
import {ButtonsModule} from 'ngx-bootstrap/buttons'


import { AppComponent } from './app.component';
import { UserListComponent } from './User/user-list.component';
import {ConfigSettingServiceService} from './config-setting-service.service';
import { AppConfig } from './app.config';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CreateuserComponent } from './User/createuser.component';


export function initializerfn(_configSettingServiceService: ConfigSettingServiceService)
{
  return ()=>{
    return _configSettingServiceService.Load(); 
  };

}

@NgModule({
  declarations: [
      AppComponent,
      UserListComponent,
      CreateuserComponent,
      
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
     HttpClientModule,
     BrowserAnimationsModule, 
     BsDatepickerModule.forRoot(), 
     ButtonsModule.forRoot(),
 

  ],
  exports:[
    BsDatepickerModule, 
    ButtonsModule, BrowserAnimationsModule
  ],
  providers: [
    {
      provide: AppConfig,
      deps: [HttpClient],
      useExisting: ConfigSettingServiceService

    },
    {
      provide : APP_INITIALIZER,
      multi: true,
      deps:[ConfigSettingServiceService],
      useFactory: initializerfn

    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
