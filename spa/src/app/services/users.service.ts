import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
//import 'rxjs/Rx';

import { BaseService } from './base.service';
import { UserProfile } from 'app/classes/user-profile';

@Injectable()
export class UsersService extends BaseService {

    constructor(private http: Http) {
        super('api/ProfileNew');
    }

    getCurrentUser(): Observable<UserProfile> {
        let username: string = localStorage.getItem("username");
        
        return this.http.get(this.url + '/ByLogin/' + username)
            .map(this.extractData)
            .catch(this.handleError);
    }

    getAllUsers(): Observable<UserProfile[]> {
        return this.http.get(this.url)
                        .map(this.extractData)
                        .catch(this.handleError);
    }

    getUserByLogin(login: string): Observable<UserProfile> {
        return this.http.get(this.url + '/ByLogin/' + login)
                        .map(this.extractData)
                        .catch(this.handleError);
    }    

    editProfile(userProfile: UserProfile): Observable<void> {
        let body = this.stringifyObject(userProfile);

        let options = new RequestOptions({ headers: this.headers });

        return this.http.put(this.url, body, options)
            .catch(this.handleError);
    }
   
    
    editPassword(newPassword: string): Observable<void> {
        let headers: Headers = new Headers();
        let token: string = 'Bearer ' + localStorage.getItem("access_token");

        headers.append("Authorization", token);

        let options = new RequestOptions({ headers: headers });

        return this.http.get(this.url + '/EditPassword/' + newPassword, options)
            .catch(this.handleError);
    }
}