import { Event } from './Event';
import { Sector } from './Sector';

export class Ticket {
    id: number;
    price: number;
    event: Event;
    sector: Sector;
}
