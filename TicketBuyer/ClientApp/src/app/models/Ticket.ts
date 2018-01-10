import { Event } from './Event';
import { Sector } from './Sector';
import { RealSeating } from './RealSeating';
export class Ticket {
    id: number;
    price: number;
    event: Event;
    sector: Sector;
    seating: RealSeating;
}
