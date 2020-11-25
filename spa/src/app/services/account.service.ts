import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';

import { UserProfile } from 'app/classes/user-profile';
import { RegistrationProfile } from 'app/classes/registration-profile';
import { BaseService } from './base.service';


@Injectable()
export class AccountService extends BaseService {

    constructor(private http: Http) {
        super('api/ProfileNew');
    }

    register(registrationProfile: RegistrationProfile): Observable<UserProfile> {
    //to change
        let body = this.stringifyObject(registrationProfile);

        let options = new RequestOptions({ headers: this.headers });

        return this.http.post(this.url, body, options)
            .map(this.extractData);
            //.catch(this.handleError);
    }

    forgetPassword(userProfile: UserProfile) {
        
    }

    isBanned(userLogin: string) {
        return this.http.get(`${this.url}/IsBanned/${userLogin}`)
            .map(this.extractData)
            .catch(this.handleError);
    }

    banUser(userId: number) {
        return this.http.get(`${this.url}/BanUser/${userId}`, this.getAuthorizationOptions())
            .catch(this.handleError);
    }
}