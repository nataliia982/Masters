import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserProfile } from 'app/classes/user-profile';
import { EventsService } from 'app/services/events.service';
import { UsersService } from 'app/services/users.service';

@Component({
    selector: 'events',
    templateUrl: './events.html'
})

export class EventsComponent {
    
    currentUser: any = new UserProfile();
    events = [];
    
    constructor(
        private router: Router,
        private eventServie: EventsService) { }

    ngOnInit(): void {

        this.eventServie.getEvents()
            .subscribe( events => { 
                this.events = events;
            });  
            this.eventServie.getEventByKey('eventKey')
            .subscribe( events => { 
            });  
        this.currentUser = localStorage.getItem("username");
    }

}