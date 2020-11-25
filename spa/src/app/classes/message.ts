export class Message {
    login: string;
    profileImageUrl: string;
    name: string;
    surname: string;
    dateCreated: Date;
    body: string;
    conversationId: number;

    constructor() {
        this.login = '';
        this.profileImageUrl = '';
        this.name = '';
        this.surname = '';
        this.dateCreated = new Date();
        this.body = '';
        this.conversationId = 0;
    }
}