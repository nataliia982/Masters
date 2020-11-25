import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { UserProfile } from 'app/classes/user-profile';
import { UsersService } from 'app/services/users.service';

@Component({
    selector: 'users',
    templateUrl: './users.html'    
})

export class UsersComponent implements OnInit {
    users: UserProfile[];
    filteredUsers: UserProfile[];
    currentUser: string;
    filter: boolean;

    constructor(
        private router: Router,
        private userService: UsersService) { }

    ngOnInit(): void {

        this.userService.getAllUsers()
            .subscribe( users => { 
                this.users = users;
                this.filteredUsers = users;
            });  

        this.currentUser = localStorage.getItem("username");
    }

    search(val: string) {
        if (!val) this.filteredUsers = this.users;
        
        this.filteredUsers = this.users.filter(x => `${ x.name.toLowerCase() } ${ x.surname.toLowerCase() }`.includes(val.toLowerCase()));
    }

    changeFilter(banned: boolean) : void {

        if(banned == undefined) {
            this.filteredUsers = this.users;
        }
        else {
            this.filteredUsers = this.users.filter(x => x.isBanned == banned);
        }  

        this.filter = banned;
    }

    onUserProfile(user: UserProfile): void {
        this.router.navigate(['/', user.login]);
    }

    onSendMessage(userId: number): void {
        this.router.navigate(['/', this.currentUser, "chat", userId]);
    }
}