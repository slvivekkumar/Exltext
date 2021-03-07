import { Injectable } from '@angular/core';
import {HttpClient} from'@angular/common/http'
import { AppConfig } from '../app.config';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserDataService {

  constructor(private  _httpClient: HttpClient, private _appConfig: AppConfig) { }
  getUsers(): Observable<any>
  {
    //console.log(this._appConfig.baseurl); 
      return this._httpClient.get(this._appConfig.baseurl+"api/Users");
  } 

  getSearchUsers(serachKeyword: string ): Observable<any>
  {
    //console.log(this._appConfig.baseurl); 
      return this._httpClient.get(this._appConfig.baseurl+"api/Users/GetSearchUsers/"+serachKeyword);

      
  } 
}
