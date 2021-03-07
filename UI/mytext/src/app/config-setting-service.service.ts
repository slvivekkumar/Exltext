import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from './app.config';

@Injectable({
  providedIn: 'root'
})
export class ConfigSettingServiceService extends  AppConfig {

  constructor(private _httpClient: HttpClient) {
    super();
   }

  Load(){
    return this._httpClient.get<AppConfig>('Globalconfig.json')
                .toPromise().
                then(data=>{
                    this.title=data.title,
                    this.baseurl = data.baseurl

                }).catch(()=>{
                  console.error('Could not load the config file.');

                });

  }

}
