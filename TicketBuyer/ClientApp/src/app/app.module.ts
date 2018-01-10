import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpModule } from "@angular/http";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AuthService } from './services/auth.service';
import { UserService } from './services/user.service';
import { OrderService } from './services/order.service';
import { EventService } from './services/event.service';
import { PlaceService } from './services/place.service';
import { AboutService } from './services/about.service';

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
import { PlacesComponent } from './components/places/places.component';
import { ViewPlaceComponent } from './components/view-place/view-place.component';
import { AddPlaceComponent } from './components/add-place/add-place.component';
import { AboutComponent } from './components/about/about.component';
import { StatusFilter } from './filters/StatusFilter';
import { TypesPipe } from './filters/TypesPipe';

const appRoutes: Routes = [
    { path: '', redirectTo: 'main', pathMatch: 'full' },
    { path: 'main', component: EventsComponent },
    { path: 'sign-in', component: SignInComponent },
    { path: 'sign-up', component: SignUpComponent },
    { path: 'profile', component: ProfileComponent },
    { path: 'add-event', component: AddEventComponent },
    { path: 'view-event/:id', component: ViewEventComponent },
    { path: 'places', component: PlacesComponent },
    { path: 'view-place/:id', component: ViewPlaceComponent },
    { path: 'add-place', component: AddPlaceComponent },
    { path: 'about', component: AboutComponent }
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
        PlacesComponent,
        ViewPlaceComponent,
        AddPlaceComponent,
        AboutComponent,
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
    providers: [AuthService, UserService, OrderService, EventService, PlaceService, AboutService],
    bootstrap: [AppComponent]
})
export class AppModule { }
