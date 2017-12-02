import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Event } from '../../models/Event';
import { UserService } from '../../services/user.service';

@Component ({
    selector: 'wish-events',
    templateUrl: './wish-events.component.html',
    styleUrls: ['./wish-events.component.scss']
})

export class WishEventsComponent {
    @Input() wishEvents: Array<Event>;
    @Output() onWishRemoved = new EventEmitter<number>();

    constructor(
        private userService: UserService
    ) { }

    remove(wishEventId: number) {
        this.userService.removeWish(wishEventId).then(result => {
            if (result.state == 1) {
                this.onWishRemoved.emit(wishEventId);
            };
        });
    }
}
