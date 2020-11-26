import { Message } from "app/classes/message";

export class ExtendedConversation {
    conversationId: number;
    messages: Message[];

    constructor() {
        this.conversationId = 0;
        this.messages = [];
    }
}