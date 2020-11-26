export class Conversation {
    id: number;
    userLogin: string;
    userImage: string;
    userName: string;
    userSurname: string;
    lastMessageDate: Date;
    lastMessageBody: string;
    isChoosen: boolean;
    conversationText: string;

    constructor() {
        this.id = 0;
        this.userLogin = '';
        this.userImage = '';
        this.userName = '';
        this.userSurname = '';
        this.lastMessageDate = new Date();
        this.lastMessageBody = '';
        this.isChoosen = false;
        this.conversationText = 'Add';
    }
}