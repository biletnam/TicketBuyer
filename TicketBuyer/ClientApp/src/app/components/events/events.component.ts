import { Component, OnInit } from '@angular/core';
import { EventService } from '../../services/event.service';
import { EventFiltersData } from '../../models/EventFiltersData';
import { EventFilter } from '../../models/EventFilter';
import { RequestResult } from '../../models/RequestResult';
import { Event } from '../../models/Event';

@Component({
    selector: 'events',
    templateUrl: './events.component.html',
    styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit{
    private eventFiltersData: EventFiltersData;
    private eventFilter: EventFilter;
    private events: Array<Event>;

    constructor(
        private eventService: EventService
    ) { }

    ngOnInit() {
        this.eventFilter = new EventFilter();
        this.eventFilter.type = null;
        this.eventFilter.status = null;
        this.eventFilter.startDate = null;
        this.eventFilter.endDate = null;
        this.eventFilter.placeId = null;

        this.eventService.getEventFiltersData().then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 1) {
                this.eventFiltersData = result.data as EventFiltersData;
            }
        });

        this.eventService.getEvents(this.eventFilter).then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 1) {
                this.events = result.data as Array<Event>;
            }
        });
    }

    onClick() {
        this.eventService.getEvents(this.eventFilter).then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 1) {
                this.events = result.data as Array<Event>;
            }
        });
    }
}
