import { Seating } from './Seating';

export class Sector {
    id: number;
    title: string;
    type: number;
    limit: number;
    seatings: Array<Seating>;
}
