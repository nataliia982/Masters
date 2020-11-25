import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
    selector: 'blocked',
    templateUrl: './blocked.html'
})

export class BlockedComponent {
    
    constructor(
        private router: Router) { }

    contactAdmin(username: any): void {
        this.router.navigate(["/", "admin"]);
    }

}