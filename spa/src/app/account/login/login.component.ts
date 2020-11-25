import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AccountService } from 'app/services/account.service';
import { AuthService } from 'app/services/auth.service';
import { Jsonp } from '@angular/http/src/http';
import { UserProfile } from 'app/classes/user-profile';

@Component({
    selector: 'login',
    templateUrl: './login.html'
})

export class LoginComponent implements OnInit {

    userAccount: UserProfile;
    rememberMe: boolean;
    errorMessage: string;

    constructor(
        private router: Router,
        private accountService: AccountService,
        private authService: AuthService
    ) { }
    
    ngOnInit(): void {
        this.userAccount = new UserProfile();
    }

    onLogin(): void {
        if (this.userAccount.login && this.userAccount.password) {

            this.authService.login(this.userAccount)
                .subscribe(
                response => {
                    if (response.access_token) {
                        localStorage.setItem("access_token", response.access_token);
                        localStorage.setItem("username", this.userAccount.login);

                        this.accountService.isBanned(this.userAccount.login).subscribe(userAccount => {
                            localStorage.setItem("userAccount", JSON.stringify(userAccount));


                            if (userAccount.isBanned) {
                                this.router.navigate(['/', this.userAccount.login, "blocked"]);
                            }
                            else {
                                this.router.navigate(['/',this.userAccount.login,'main']);
                            }
                        });
                    }                    
                },
                error => {
                    this.errorMessage = error.json().error_description;
                });

        }

        return;
    }
}