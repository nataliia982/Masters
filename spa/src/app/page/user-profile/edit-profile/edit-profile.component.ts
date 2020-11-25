import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import {NgForm} from '@angular/forms';

import { UserProfile } from 'app/classes/user-profile';
import { UsersService } from 'app/services/users.service';

@Component({
    selector: 'edit-profile',
    templateUrl: './edit-profile.html'
})

export class EditProfileComponent implements OnInit {
    user: UserProfile = new UserProfile();
    userOriginal: UserProfile = new UserProfile();
    newPassword: string;
    passwordConfirmation: string;

    constructor(
        private route: ActivatedRoute,
        private userService: UsersService) { }

    ngOnInit(): void {             
        this.userService.getCurrentUser()
            .subscribe(user => {
                this.userOriginal = user;
                this.user = Object.assign(new UserProfile(), this.userOriginal);
            });        
    }

    onSaveChanges(): void {
        this.userService.editProfile(this.user)
            .subscribe();

        this.userOriginal = Object.assign(new UserProfile(), this.user);
    }

    editPassword(form: NgForm): void {
        this.userService.editPassword(this.newPassword)
            .subscribe(response => {
                let passCopy = this.newPassword;//.substr(0);
                form.reset();
                this.newPassword = "";
                this.passwordConfirmation = "";
                this.user.password = passCopy;
            });
    }

    onCancel(): void {
        this.user = Object.assign(new UserProfile(), this.userOriginal);
        this.newPassword = "";
        this.passwordConfirmation = "";
    }
}