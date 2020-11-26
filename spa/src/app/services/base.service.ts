import { Response, Http, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';

export class BaseService {

    protected url: string;
    protected headers: Headers;

    constructor(url: string) {
        //this.url = 'http://localhost:60474/' + url; // Python
        this.url = 'http://localhost:60473/' + url; // c#
        
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
    }

    protected getAuthorizationOptions(): RequestOptions {
        let token: string = 'Bearer ' + localStorage.getItem("access_token");
        this.headers.set("Authorization", token);
        return new RequestOptions({ headers: this.headers });
    }

    protected stringifyObject(object: any) {
        let jsonObject = JSON.stringify(object);
        return jsonObject;
    }

    protected extractData(response: Response) {
        let body = response.json();
        return body || {};
    }

    protected handleError(error: any)  {
        let errDscr = error.json().error_description;

        //let errMsg = (error.message) ? error.message :
         //   error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        //console.error(errMsg);
        
        return Observable.throw(errDscr);
    }
}