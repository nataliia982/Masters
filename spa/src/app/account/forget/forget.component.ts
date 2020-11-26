import { Component, OnInit } from '@angular/core';

import { AccountService } from 'app/services/account.service';
import { UserProfile } from 'app/classes/user-profile';

@Component({
    selector: 'forget',
    templateUrl: './forget.html'
})

export class ForgetComponent implements OnInit {

    userAccount: UserProfile;

    constructor(private accountService: AccountService) { }
    
    ngOnInit(): void {
        this.userAccount = new UserProfile();
    }

    onSubmit(): void {
        if (this.userAccount.email) {
            console.log(this.userAccount.email);
        }

        return;        
    }

    onBack(): void {
        window.history.back();
    }
}