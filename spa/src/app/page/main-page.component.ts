import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
//import { BrowserDomAdapter } from '@angular/platform-browser/src/browser/browser_adapter';

import { UserProfile } from 'app/classes/user-profile';
import { UsersService } from 'app/services/users.service';

@Component({
    selector: 'main-page',
    templateUrl: './main-page.html'
})

export class MainPageComponent implements OnInit { 
    private username: string;
    private currentUser: UserProfile;
    
    constructor(   
        private router: Router,     
        private route: ActivatedRoute,
        private userService: UsersService ) {
        this.currentUser = new UserProfile();
    }

    ngOnInit(): void {
        this.userService.getCurrentUser()
            .subscribe( user => {
                this.currentUser = user;
                this.username = user.login;
            });
    }

    mainPageClicked() {
        this.router.navigate(['/', this.username, "main"]);
    }

    onEvents() {        
        this.router.navigate(['/', this.username, "events"]);
    }

    onEditProfile(): void {
        this.router.navigate(['/', this.username, "edit"]);
    }

    onMyProfile(): void {
        this.router.navigate(['/', this.username]);
    }
    
    onDashboard(): void {
        this.router.navigate(['/', this.username, "dashboard"]);
    }

    onNewComment() {
        this.router.navigate(['/', 'admin']);
    }

    onUsers(): void {
        this.router.navigate(['/', this.username, "users"]);
    }

    onChats(): void {
        this.router.navigate(['/', this.username, "chats"]);
    }

    logout(): void {
        localStorage.removeItem("access_token");
        localStorage.removeItem("username");
        localStorage.removeItem("userAccount");
        localStorage.removeItem("writeToUser");
        this.router.navigate(['/login']);
    }

}