import { ModuleWithProviders } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { AuthGuard } from './services/guards/auth-guard.service'; 
import { LoginGuard } from './services/guards/login-guard.service';

import { LoginComponent } from "./account/login/login.component";
import { RegistrationComponent } from "./account/registration/registration.component";
import { ForgetComponent } from "./account/forget/forget.component";
import { MainPageComponent } from "./page/main-page.component";

import { UsersComponent } from "./page/users/users.component";
import { DashboardComponent } from "./page/dashboard/dashboard.component";
import { ChatComponent } from "./page/chat/chat.component";
import { ConversationComponent } from "./page/chat/conversation/conversation.component";
import { UserProfileComponent } from "./page/user-profile/user-profile.component";
import { EditProfileComponent } from "./page/user-profile/edit-profile/edit-profile.component";
import { BlockedComponent } from "./page/blocked/blocked.component";
import { EventsComponent } from "./page/events/events.component";
import { MainComponent } from "./page/main/main.component";

const appRoutes: Routes = [
    {
        path: "",
        redirectTo: "/login",
        pathMatch: "full"
    },
    {
        path: "login",
        component: LoginComponent,
        canActivate: [LoginGuard]
    },
    {
        path: "main",
        component: MainComponent,
    },
    {
        path: "registration",
        component: RegistrationComponent,
        canActivate: [LoginGuard]
    },
    {
        path: "forgetPassword",
        component: ForgetComponent,
        canActivate: [LoginGuard]
    },
    {
        path: ":username",
        component: MainPageComponent,
        canActivate: [ AuthGuard ],
        children: [
            {
                path: "",
                canActivateChild: [AuthGuard],
                children: [
                    { path: "",             component: UserProfileComponent }, //redirect from here
                    { path: "dashboard",    component: DashboardComponent },
                    { path: "users",        component: UsersComponent }, //redirect from here (only admin)
                    { path: "chats",        component: ChatComponent }, //redirect from here (only admin)
                    { path: "chat/:userId", component: ConversationComponent }, //redirect from here (only admin)
                    { path: "edit",         component: EditProfileComponent },
                    { path: "events",         component: EventsComponent },
                    { path: "main",         component: MainComponent },
                    { path: "blocked",      component: BlockedComponent }
                ]
            }
        ],
    }//,
    //{
    //    path: "chat/:userId",
    //    component: ChatComponent,
    //    canActivate: [ AuthGuard ]
    //}    
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);