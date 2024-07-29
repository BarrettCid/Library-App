import { HttpClient, HttpHeaderResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SessionService } from './session/session.service';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
    
    constructor(protected sessionService: SessionService) { }

    public buildHeaders() {
        if(this.sessionService.getToken() == undefined){
            return new HttpHeaders({
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': "*"
            });
        }
        else{
            return new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this.sessionService.getToken()}`,
                'Access-Control-Allow-Origin': "*"
            });
        }
        
    }

    public buildMultipartHeaders(){
        if(this.sessionService.getToken() == undefined){
            return new HttpHeaders({
                'Access-Control-Allow-Origin': "*"
            });
        }
        else{
            return new HttpHeaders({
                'Authorization': `Bearer ${this.sessionService.getToken()}`,
                'Access-Control-Allow-Origin': "*"
            });
        }
    }
}
