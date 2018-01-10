import { Injectable } from '@angular/core';

import { Http, URLSearchParams } from '@angular/http';
import { EventFilter } from '../models/EventFilter';

@Injectable()
export class EventService {
    constructor(
        private http: Http
    ) { }

    getEventFiltersData() {
        return this.http.get('api/Event/GetEventFiltersData').toPromise();
    }

    addEvent(title: string, information: string, datetime: Date, type: number, placeId: number) {
        return this.http.post('api/Event/AddEvent',
            {
                Name: title,
                DateTime: datetime,
                TypeId: type,
                Information: information,
                PlaceId: placeId
            }).toPromise();
    }

    getEvents(eventFilter: EventFilter) {
        let requestParams = new URLSearchParams();
        requestParams.append('type', eventFilter.type && eventFilter.type.toString());
        requestParams.append('status', eventFilter.status && eventFilter.status.toString());
        requestParams.append('startDate', eventFilter.startDate && eventFilter.startDate.toString());
        requestParams.append('endDate', eventFilter.endDate && eventFilter.endDate.toString());
        requestParams.append('placeId', eventFilter.placeId && eventFilter.placeId.toString());

        return this.http.get('api/Event/GetEvents', { params: requestParams }).toPromise();
    }

    getEvent(eventId: number) {
        let requestParams = new URLSearchParams();
        requestParams.append('eventId', eventId.toString());

        return this.http.get('api/Event/GetEvent', { params: requestParams }).toPromise();
    }

    sendComment(comment: string, eventId: number) {
        return this.http.post('api/EventComment/AddComment', { comment: comment, eventId: eventId }).toPromise();
    }

    getComments(eventId: number) {
        let requestParams = new URLSearchParams();
        requestParams.append('eventId', eventId.toString());

        return this.http.get('api/EventComment/GetComments', { params: requestParams }).toPromise();
    }

    addWishEvent(eventId: number) {
        return this.http.post('api/Profile/AddWishEvent', { WishEventId: eventId }).toPromise();
    }
}
