import { Injectable } from '@angular/core';
import { Http, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
//import 'rxjs/Rx';

import { BaseService } from './base.service';
import { FeedMessage } from 'app/classes/feed-message';

@Injectable()
export class FeedMessageService extends BaseService {

   constructor(private http: Http) {
       super('api/FeedMessageNew');
   }

   getUserFeeds(id: number): Observable<FeedMessage[]> {
        let url: string = this.url + '/ByUser/' + id;
    
        return this.http.get(url, this.getAuthorizationOptions())
            .map(this.extractData)
            .catch(this.handleError);
   }

   createFeed(newFeed: FeedMessage): Observable<FeedMessage> {

       let body = this.stringifyObject(newFeed);

       return this.http.post(this.url, body, this.getAuthorizationOptions())
           .map(this.extractData)
           .catch(this.handleError);
   }

   updateFeed(feed: FeedMessage): Observable<FeedMessage> {
    
        let body = this.stringifyObject(feed);

        return this.http.put(this.url, body, this.getAuthorizationOptions())
            .map(this.extractData)
            .catch(this.handleError);
    }

    deleteFeed(id: number): Observable<FeedMessage> {

        let url: string = this.url + '/' + id;

        return this.http.delete(url, this.getAuthorizationOptions())
            .catch(this.handleError);
    }

}