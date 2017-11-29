import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpModule } from "@angular/http";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AuthService } from './services/auth.service';

import { AppComponent } from './components/app/app.component';
import { TopNavigationComponent } from './components/top-navigation/top-navigation.component';
import { MainComponent } from './components/main/main.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { ProfileComponent } from './components/profile/profile.component';

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
    ProfileComponent
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
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
