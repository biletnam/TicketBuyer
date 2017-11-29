import { Component } from '@angular/core';

@Component({
    selector: 'top-navigation',
    templateUrl: './top-navigation.component.html',
    styleUrls: ['./top-navigation.component.scss']
})
export class TopNavigationComponent {
    isLogged = false;
    links = [
        { href: 'main', title: 'Main' },
        { href: 'sign-in', title: 'Sign in' },
        { href: 'profile', title: 'My Profile'},
        { href: 'about-us', title: 'About us' }
    ];
}
