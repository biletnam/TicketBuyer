import { Event } from './Event';

export class Place {
    id: number;
    name: string;
    address: string;
    events: Array<Event>;
    placePhotos: Array<string>;
}
