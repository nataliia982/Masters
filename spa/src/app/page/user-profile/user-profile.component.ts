import { Component, OnInit } from '@angular/core';
import { Router, Params, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/mergeMap';

import { UserProfile } from 'app/classes/user-profile';
import { FeedMessage } from 'app/classes/feed-message';
import { UsersService } from 'app/services/users.service';
import { AccountService } from 'app/services/account.service';
import { FeedMessageService } from 'app/services/feed-message.service';

@Component({
    selector: 'user-profile',
    templateUrl: './user-profile.html'
})

export class UserProfileComponent implements OnInit {
    user: UserProfile = new UserProfile();
    currentUser: UserProfile = new UserProfile();
    feedMessages: FeedMessage[] = [];
    newFeedMessage: FeedMessage = new FeedMessage();
    updateFeedMessage: FeedMessage = new FeedMessage();
    originalFeedMessage: FeedMessage = new FeedMessage();
    
    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private userService: UsersService,
        private accountService: AccountService,
        private feedMessageService: FeedMessageService
    ) { }

    ngOnInit(): void {
        let username: string; 
        this.route.params.forEach((params: Params) => {
            username = params['username'];

            // get user on whose page we are
            this.userService.getUserByLogin(username)
                .flatMap( user => {
                    this.user = user;
                    return this.feedMessageService.getUserFeeds(user.id) 
                })
                .subscribe(feeds => this.feedMessages = feeds);

            // get user who is logged in
            this.userService.getCurrentUser()
                .subscribe(user => this.currentUser = user);
        });                
    }

    onSendMessage(): void {
        this.router.navigate(['/', this.currentUser.login, "chat", this.user.id]);
    }

    goToUser(login: string) : void {
        this.router.navigate(['/', login]);
    }

    onBanUser(userId: number, ban: boolean) {
        this.accountService.banUser(userId)
            .subscribe(x => {
                this.user.isBanned = ban;
            });
    }

    onPostMessage(): void {

        if (this.newFeedMessage.feedText) {
            this.newFeedMessage.dateCreated = new Date();
            this.newFeedMessage.userId = this.user.id;

            this.feedMessageService.createFeed(this.newFeedMessage)
                .subscribe(feed => {
                    this.feedMessages.unshift(feed);
                    this.newFeedMessage = new FeedMessage();
                });
        }
    }

    onUpdateClick(feed: FeedMessage): void {
        this.updateFeedMessage = Object.assign(new FeedMessage(), feed);
        this.originalFeedMessage = Object.assign(new FeedMessage(), feed);
    }

    onCancelClick(feed: FeedMessage): void {
        feed = Object.assign(new FeedMessage(), this.originalFeedMessage);
        this.updateFeedMessage = new FeedMessage();
    }

    onUpdatePostMessage(): void {
        this.feedMessageService.updateFeed(this.updateFeedMessage).subscribe(() => {
            var feed = this.feedMessages.find(x => x.id == this.updateFeedMessage.id);
            
            feed.feedText = this.updateFeedMessage.feedText;
            feed.wasEdited = true;
    
            this.updateFeedMessage = new FeedMessage();
        });
    }

    onDeletePostMessage(id: number): void {
        this.feedMessageService.deleteFeed(id)
            .subscribe(() => this.feedMessages = this.feedMessages.filter(x => x.id !== id));
    }
}