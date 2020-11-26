import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';

import { BaseService } from './base.service';


@Injectable()
export class EventsService extends BaseService {

    constructor(private http: Http) {
        super('api/Events');
    }

    getEventByKey(id: string): Observable<any[]> {

        let header: Headers = new Headers();
        let token: string = 'Bearer ' + localStorage.getItem("access_token");

        header.append("Authorization", token);

        let options = new RequestOptions({ headers: header });
        let url: string = this.url + '/ByKey/' + id;

        return this.http.get(url, options)
            .map(this.extractData)
            .catch(this.handleError);
    }
    getEvents(): Observable<any[]> {

        let header: Headers = new Headers();
        let token: string = 'Bearer ' + localStorage.getItem("access_token");

        header.append("Authorization", token);

        let options = new RequestOptions({ headers: header });
        let url: string = this.url

        return this.http.get(url, options)
            .map(this.extractData)
            .catch(this.handleError);
    }
}