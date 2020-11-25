export class NewMessage {
    body: string;
    conversationId: number;

    constructor() {
        this.conversationId = 0;
        this.body = '';
    }
}