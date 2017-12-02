import { Ticket } from './Ticket';
import { OrderStatus } from '../enums/OrderStatus';

export class Order {
    id: number;
    tickets: Array<Ticket>;
    status: OrderStatus;    
}
