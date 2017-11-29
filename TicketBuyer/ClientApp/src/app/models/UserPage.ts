import { User } from './User';
import { Event } from './Event';
import { Order } from './Order';

export class UserPage {
    user: User;
    wishEvents: Array<Event>;
    orders: Array<Order>;
}
