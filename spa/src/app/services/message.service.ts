import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';

import { Message } from 'app/classes/message';
import { BaseService } from './base.service';
import { NewMessage } from 'app/classes/new-message';


@Injectable()
export class MessageService extends BaseService {

    constructor(private http: Http) {
        super('api/MessageNew');
    }

    sendMessage(message: NewMessage): Observable<Message> {
        
        let token: string = 'Bearer ' + localStorage.getItem("access_token");
        this.headers.set("Authorization", token);
        let options = new RequestOptions({ headers: this.headers });

        let body = this.stringifyObject(message);

        return this.http.post(this.url, body, options)
                   .map(this.extractData);
    }
}