import { Place } from './Place';

export class EventFiltersData {
    places: Array<Place>;
    types: { [key: number]: string };
    statuses: { [key: number]: string };
}
