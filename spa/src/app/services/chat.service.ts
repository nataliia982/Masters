import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';

import { Conversation } from 'app/classes/conversation';
import { Message } from 'app/classes/message';
import { BaseService } from './base.service';
import { ExtendedConversation } from 'app/classes/extended-conversation';
import { UserProfile } from 'app/classes/user-profile';


@Injectable()
export class ChatService extends BaseService {

    constructor(private http: Http) {
        super('api/ConversationNew');
    }

    getConversation(id: number): Observable<ExtendedConversation> {

        let header: Headers = new Headers();
        let token: string = 'Bearer ' + localStorage.getItem("access_token");

        header.append("Authorization", token);

        let options = new RequestOptions({ headers: header });
        let url: string = this.url + '/ByUser/' + id;

        return this.http.get(url, options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    getLatestConversations(): Observable<Conversation[]> {

        let header: Headers = new Headers();
        let token: string = 'Bearer ' + localStorage.getItem("access_token");

        header.append("Authorization", token);

        let options = new RequestOptions({ headers: header });
        let url: string = this.url + '/LatestByUser';

        return this.http.get(url, options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    getUsers(convs: Conversation[]) : Observable<UserProfile[]> {
        console.log("in chat service");
        let body = this.stringifyObject(convs);

        return this.http.post(this.url, body, this.getAuthorizationOptions())
        .map(this.extractData)
        .catch(this.handleError);
    }
}