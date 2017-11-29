import { Ticket } from './Ticket';

export class Order {
    id: number;
    tickets: Array<Ticket>;
    status: number;
    
}
