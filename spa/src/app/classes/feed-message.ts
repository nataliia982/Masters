import { UserProfile } from 'app/classes/user-profile';

export class FeedMessage {
    id: number;
    dateCreated: Date;
    feedText: string;
    wasEdited: boolean;
    
    profileImageUrl: string;
    email: string;
    name: string;
    surname: string;
    userId: number;

    
    constructor() {
        this.id = 0;
        this.dateCreated = new Date();
        this.feedText = "";
        this.wasEdited = false;

        this.profileImageUrl = "";
        this.email = "";
        this.name = "";
        this.surname = "";
        this.userId = 0;
    }
}