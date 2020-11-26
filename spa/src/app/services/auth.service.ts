import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';

import { UserProfile } from 'app/classes/user-profile';
import { BaseService } from './base.service';

@Injectable()
export class AuthService extends BaseService {
    //isLoggedIn: boolean = false;

    // store the URL so we can redirect after logging in
    redirectUrl: string;

    constructor(private http: Http) {
        super('token');
    }

    login(userAccount: UserProfile): Observable<any> { 
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/x-www-form-urlencoded');
        this.headers.append('Content-Type', 'application/json');

        let body: string = "username=" + userAccount.login + "&password=" + userAccount.password + "&grant_type=password";

        let options = new RequestOptions({ headers: this.headers });

        return this.http.post(this.url, body, options)
            .map(this.extractData);
            //.catch(this.handleError);
    }

    newLogin(login: string, password: string): Observable<any> {
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/x-www-form-urlencoded');
        this.headers.append('Content-Type', 'application/json');
        let body: string = "username=" + login + "&password=" + password + "&grant_type=password";
        

                let options = new RequestOptions({ headers: this.headers });
        
                return this.http.post(this.url, body, options)
                    .map(this.extractData);
    }
}
