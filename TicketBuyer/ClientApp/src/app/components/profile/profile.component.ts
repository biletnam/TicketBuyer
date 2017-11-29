import { Component } from '@angular/core';

@Component({
    selector: 'profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
    title = 'Profile';

    albums = ['All', 'Nature', 'People'];

    images = [
        'http://luxfon.com/images/201302/luxfon.com_19801.jpg',
        'http://media-cache-ec0.pinimg.com/736x/c3/10/22/c3102281f88237e7a2515099d2e6651f.jpg',
        'http://media-cache-ak0.pinimg.com/736x/2e/7f/db/2e7fdb7ed765973407fed0b0141bb126.jpg',
        'http://media-cache-ec0.pinimg.com/600x/97/35/91/97359142dce582b4530cb0f23fbe2e43.jpg'
    ];
}
