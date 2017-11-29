import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/User';
import { UserPage } from '../../models/UserPage';
import { RequestResult } from '../../models/RequestResult';

@Component({
    selector: 'profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
    private userPage: UserPage;

    constructor(
        private userService: UserService,
    ) {
    }

    ngOnInit() {
        this.userService.getUserProfile().subscribe(response => {
            let result = response.json() as RequestResult;

            if (result.state == 1) {
                this.userPage = result.data as UserPage;
            }
        });
    }
}
