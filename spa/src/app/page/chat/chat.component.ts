import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { Conversation } from "app/classes/conversation";
import { Message } from "app/classes/message";
import { UserProfile } from "app/classes/user-profile";
import { ChatService } from "app/services/chat.service";
import { forEach } from "@angular/router/src/utils/collection";

@Component({
    selector: 'chat',
    templateUrl: './chat.html'
})

export class ChatComponent implements OnInit {
    conversations: Conversation[];
    filteredConversations: Conversation[];
    selectedConversations: Conversation[];
    selectedIds: Number[];
    currentUsername: string;
    isChat: boolean
    
    constructor(
        private router: Router,
        private chatService: ChatService) { 
            this.isChat = true;
        }

    ngOnInit() {

        this.chatService.getLatestConversations()
            .subscribe(conversations => {
                console.log(conversations);

                for (var i = 0; i < conversations.length; i++) {
                    conversations[i].conversationText = "Add";
                    conversations[i].isChoosen = false;
                }

                this.conversations = conversations;
                this.filteredConversations = conversations;
                this.selectedConversations = [];
                this.selectedIds = [];
            });    

        this.currentUsername = localStorage.getItem("username");        
    }

    onChatOpen(conversationId: number): void {  
        // localStorage.setItem("writeToUser", JSON.stringify(userProfile) );    
        this.router.navigate(['/', this.currentUsername, "chat", conversationId]);
    }

    search(val: string) {
        if (!val) this.filteredConversations = this.conversations;
        this.filteredConversations = this.conversations.filter(x => `${ x.userName.toLowerCase() } ${ x.userSurname.toLowerCase() }`.includes(val.toLowerCase()));
    }


    onUserProfile(username: any): void {
        this.router.navigate(["/", username]);
    }


    addConv(conversation: Conversation): void {
        if (conversation.isChoosen) {
            conversation.conversationText = "Add";
            conversation.isChoosen = false;
            this.selectedConversations.pop();
        } else {
            conversation.conversationText = "Close";
            conversation.isChoosen = true;
            this.selectedConversations.push(conversation);
        }
    }

    showAllPart(): void {
        this.isChat = false;
        console.log("in show all");

        this.selectedConversations = [];
        this.conversations.forEach(element => {
            if (element.isChoosen == true) {
                this.selectedConversations.push(element);
            }
        });


        console.log("end show all");
             
    }

    cancelShowList(): void {
        this.isChat = true;
    }
}