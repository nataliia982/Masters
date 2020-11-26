import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { UserProfile } from 'app/classes/user-profile';
import { RegistrationProfile } from 'app/classes/registration-profile';
import { AccountService } from 'app/services/account.service';
//import { EqualValidator } from 'app/equal-validator.directive';
import { AuthService } from 'app/services/auth.service';

@Component({
    selector: 'registration',
    templateUrl: './registration.html'//,
    //directives: [ EqualValidator ]
})

export class RegistrationComponent implements OnInit {

    passwordConfirmation: string;
    errorMessage: string;
    registrationProfile: RegistrationProfile;
    

    constructor(
        private router: Router,
        private accountService: AccountService,
        private authService: AuthService ) { }

    ngOnInit(): void {
        this.registrationProfile = new RegistrationProfile();
    }

    onSignUp(): void {
        if (this.registrationProfile.name && this.registrationProfile.surname && this.registrationProfile.email
            && this.registrationProfile.login && this.registrationProfile.password) {

            this.accountService.register(this.registrationProfile)
                .subscribe(
                    user => {
                        this.authService.newLogin(user.login, user.password)
                            .subscribe(response => {
                                if (response.access_token) {
                                    localStorage.setItem("access_token", response.access_token);
                                    localStorage.setItem("username", user.login);

                                    this.router.navigate(['/', user.login]);
                                }
                            });
                    },
                    error => {
                        this.errorMessage = error.json().exceptionMessage;
                    }
            );
            
        }

        return;
    }

    onBack(): void {        
        window.history.back();
    }    
}