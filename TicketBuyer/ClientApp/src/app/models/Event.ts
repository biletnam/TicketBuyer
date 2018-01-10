import { Place } from './Place';
import { EventComment } from './EventComment';

export class Event {
    id: number;
    name: string;
    information: string;
    dateTime: Date;
    place: Place;
    eventComments: Array<EventComment>;
    eventPhotos: Array<string>;
}
