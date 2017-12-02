import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/User';
import { UserPage } from '../../models/UserPage';
import { RequestResult } from '../../models/RequestResult';
import { OrderStatus } from '../../enums/OrderStatus';
@Component({
    selector: 'profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
    private userPage: UserPage;
    private statuses = Object.keys(OrderStatus).map(k => OrderStatus[k]);

    constructor(
        private userService: UserService,
    ) {
    }

    ngOnInit() {
        let i = OrderStatus['Wait for payment'];

        this.userService.getUserProfile().then(response => {
            let result = response;

            if (result.state == 1) {
                this.userPage = result.data as UserPage;
            }
        });
    }

    onPaid(orderId: number) {
        this.userPage.orders.find(x => x.id == orderId).status = 2;
    }

    onCancel(orderId: number) {
        this.userPage.orders.find(x => x.id == orderId).status = 3;
    }

    onWishRemoved(wishEventId: number) {
        this.userPage.wishEvents = this.userPage.wishEvents.filter(x => x.id !== wishEventId);
    }
}
