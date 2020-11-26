import { Injectable }       from '@angular/core';
import {
    CanActivate,
    CanActivateChild,
    Router,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
}                           from '@angular/router';

import { AuthService }      from 'app/services/auth.service';

@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild {
    constructor(private authService: AuthService, private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        this.authService.redirectUrl = state.url;

        if (localStorage.getItem("access_token") && localStorage.getItem("username")) {

            return true;
        }

        this.router.navigate(['/login']);
    }

    canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        return this.canActivate(route, state);
    }
} 