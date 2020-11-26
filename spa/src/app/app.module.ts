import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';

import { LoginComponent } from './account/login/login.component';
import { RegistrationComponent } from './account/registration/registration.component';
import { ForgetComponent } from './account/forget/forget.component';
import { AccountHeaderComponent } from './account/account-header.component';
import { AccountFooterComponent } from './account/account-footer.component';

import { MainPageComponent } from './page/main-page.component';
import { UsersComponent } from './page/users/users.component';
import { DashboardComponent } from './page/dashboard/dashboard.component';
import { ChatComponent } from './page/chat/chat.component';
import { ConversationComponent } from './page/chat/conversation/conversation.component'
import { UserProfileComponent } from './page/user-profile/user-profile.component';
import { EditProfileComponent } from './page/user-profile/edit-profile/edit-profile.component';
import { BlockedComponent } from './page/blocked/blocked.component';

import { AccountService } from './services/account.service';
import { UsersService } from './services/users.service';
import { MessageService } from './services/message.service';
import { ChatService } from './services/chat.service';
import { FeedMessageService } from './services/feed-message.service';
import { AuthGuard } from './services/guards/auth-guard.service';
import { LoginGuard } from './services/guards/login-guard.service';
import { AuthService } from './services/auth.service'; 

import { EqualValidator } from './utils/equal-validator.directive';
import { routing } from './app.routing';
import { EventsComponent } from './page/events/events.component';
import { EventsService } from './services/events.service';
import { MainComponent } from './page/main/main.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    ForgetComponent,
    EventsComponent,
    AccountHeaderComponent,
    AccountFooterComponent,
    MainPageComponent,
    UsersComponent,
    DashboardComponent,        
    ChatComponent,
    ConversationComponent,
    UserProfileComponent,
    EditProfileComponent,
    BlockedComponent,
    EqualValidator,
    MainComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing
  ],
  providers: [
    EventsService,
    AccountService,
    UsersService,
    MessageService,
    ChatService,
    FeedMessageService,
    AuthGuard,
    LoginGuard,
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
