import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { User } from '../../models/User';
import { RequestResult } from '../../models/RequestResult';

@Component({
    selector: 'top-navigation',
    templateUrl: './top-navigation.component.html',
    styleUrls: ['./top-navigation.component.scss']
})
export class TopNavigationComponent implements OnInit {
    private links: Array<any>;

    private user: User;

    constructor(
        private authService: AuthService)
    { }

    ngOnInit() {
        this.authService.getCurrentUser().then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 1) {
                this.user = result.data as User;

            }
            this.links = [
                { href: 'main', title: 'Main', show: true },
                { href: 'sign-in', title: 'Sign in', show: this.user == undefined },
                { href: 'profile', title: 'My Profile', show: this.user != undefined },
                { href: 'places', title: 'Places', show: true },
                { href: 'add-event', title: 'Add Event', show: this.user && this.user.role == 3},
                { href: 'add-place', title: 'Add Place', show: this.user && this.user.role == 3},
                { href: 'about', title: 'About us', show: true },
                { href: 'logout', title: 'Log out', show: this.user != undefined }
            ];

        });
        
    }
}
