import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute, Params } from "@angular/router";

import { Conversation } from "app/classes/conversation";
import { Message } from "app/classes/message";
import { ChatService } from "app/services/chat.service";
import { MessageService } from "app/services/message.service";
import { UserProfile } from "app/classes/user-profile";
import { NewMessage } from "app/classes/new-message";

@Component({
    selector: 'chat',
    templateUrl: './conversation.html'
})

export class ConversationComponent implements OnInit {
    conversationId: number;
    messages: Message[];
    newMessage: NewMessage;
    currentUsername: string;
    disableChatting: boolean;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private chatService: ChatService,
        private messageService: MessageService) {
        this.newMessage = new NewMessage();
    }

    ngOnInit() {
        this.route.params.forEach((params: Params) => {
            let id = +params['userId'];

            this.chatService.getConversation(id)
                .subscribe(conversation => {
                    this.messages = conversation.messages;
                    this.conversationId = conversation.conversationId;
                    const currentUser = <any>(JSON.parse(localStorage.getItem("userAccount")));
                    const fromUser = <string>(JSON.parse(localStorage.getItem("writeToUser")));
                    
                    //this.disableChatting = currentUser.isBanned && (fromUser !== 'admin');
                }).add(() => {
                    //this.messages = this.conversation.messages;
                    this.currentUsername = localStorage.getItem("username");
                    this.scrollDown(this.messages.length);
                });
        });
    }

    onSendMessage(): void {
        if (this.newMessage.body) {
            this.newMessage.conversationId = this.conversationId;

            this.messageService.sendMessage(this.newMessage)
                .subscribe(message => {
                    this.messages.push(message);
                    this.newMessage = <NewMessage>{};
                    this.scrollDown(this.messages.length);
                });

        }

        return;
    }

    onUserProfile(username: any): void {
        this.router.navigate(["/", username]);
    }

    private scrollDown(length: number): void {
        setTimeout(() => {
            var container = document.querySelectorAll("#container")[0];
            var content = document.querySelectorAll("#content")[0];

            if (!!container && !!content && content.clientHeight !== 0) {
                container.scrollTop = content.clientHeight;
            } else if (length != 0) {
                this.scrollDown(this.messages.length);
            }
        }, 50);

        
    }
}