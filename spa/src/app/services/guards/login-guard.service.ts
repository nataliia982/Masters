import { Injectable }   from '@angular/core';
import {
    CanActivate,
    Router
}                       from '@angular/router';

@Injectable()
export class LoginGuard implements CanActivate {
    constructor(private router: Router) { }

    canActivate(): boolean {
        if ( !(localStorage.getItem("access_token") && localStorage.getItem("username")) ) {
            return true;
        }

        this.router.navigate(['/', localStorage.getItem("username")]);
    }
} 