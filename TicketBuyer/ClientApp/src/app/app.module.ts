import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpModule } from "@angular/http";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AuthService } from './services/auth.service';
import { UserService } from './services/user.service';
import { OrderService } from './services/order.service';
import { EventService } from './services/event.service';

import { AppComponent } from './components/app/app.component';
import { TopNavigationComponent } from './components/top-navigation/top-navigation.component';
import { MainComponent } from './components/main/main.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { ProfileComponent } from './components/profile/profile.component';
import { WishEventsComponent } from './components/wish-events/wish-events.component';
import { OrdersComponent } from './components/orders/orders.component';
import { AddEventComponent } from './components/add-event/add-event.component';
import { EventsComponent } from './components/events/events.component';
import { ViewEventComponent } from './components/view-event/view-event.component';
import { EventCommentsComponent } from './components/event-comments/event-comments.component';
import { StatusFilter } from './filters/StatusFilter';
import { TypesPipe } from './filters/TypesPipe';

const appRoutes: Routes = [
    { path: '', redirectTo: 'main', pathMatch: 'full' },
    { path: 'main', component: EventsComponent },
    { path: 'sign-in', component: SignInComponent },
    { path: 'sign-up', component: SignUpComponent },
    { path: 'profile', component: ProfileComponent },
    { path: 'add-event', component: AddEventComponent },
    { path: 'view-event/:id', component: ViewEventComponent }
];
@NgModule({
    declarations: [
        AppComponent,
        TopNavigationComponent,
        MainComponent,
        SignInComponent,
        SignUpComponent,
        ProfileComponent,
        WishEventsComponent,
        OrdersComponent,
        AddEventComponent,
        EventsComponent,
        ViewEventComponent,
        EventCommentsComponent,
        StatusFilter,
        TypesPipe
    ],
    imports: [
        RouterModule.forRoot(
            appRoutes,
            { enableTracing: true }),
        BrowserModule,
        HttpModule,
        ReactiveFormsModule,
        FormsModule
    ],
    providers: [AuthService, UserService, OrderService, EventService],
    bootstrap: [AppComponent]
})
export class AppModule { }
