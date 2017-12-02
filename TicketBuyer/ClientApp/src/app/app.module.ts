import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpModule } from "@angular/http";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AuthService } from './services/auth.service';
import { UserService } from './services/user.service';
import { OrderService } from './services/order.service';

import { AppComponent } from './components/app/app.component';
import { TopNavigationComponent } from './components/top-navigation/top-navigation.component';
import { MainComponent } from './components/main/main.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { ProfileComponent } from './components/profile/profile.component';
import { WishEventsComponent } from './components/wish-events/wish-events.component';
import { OrdersComponent } from './components/orders/orders.component';
import { StatusFilter } from './filters/StatusFilter';

const appRoutes: Routes = [
    { path: '', redirectTo: 'main', pathMatch: 'full' },
    { path: 'main', component: MainComponent },
    { path: 'sign-in', component: SignInComponent },
    { path: 'sign-up', component: SignUpComponent },
    { path: 'profile', component: ProfileComponent }
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
    StatusFilter
  ],
  imports: [
      RouterModule.forRoot(
          appRoutes,
      {enableTracing: true }),
      BrowserModule,
      HttpModule,
      ReactiveFormsModule,
      FormsModule
  ],
  providers: [AuthService, UserService, OrderService],
  bootstrap: [AppComponent]
})
export class AppModule { }
