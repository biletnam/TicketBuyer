import { Component, OnInit } from '@angular/core';
import { EventService } from '../../services/event.service';
import { Event } from '../../models/Event';
import { EventComment } from '../../models/EventComment';
import { ActivatedRoute } from '@angular/router';
import { RequestResult } from '../../models/RequestResult';

@Component({
    selector: 'view-event',
    templateUrl: './view-event.component.html',
    styleUrls: ['./view-event.component.scss']
})

export class ViewEventComponent implements OnInit {
    private event: Event;
    private successMessage: string;

    constructor(
        private eventService: EventService,
        private route: ActivatedRoute

    ) { }

    addWishEvent() {
        let eventId = Number.parseInt(this.route.snapshot.paramMap.get('id'));
        this.eventService.addWishEvent(eventId).then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 1) {
                this.successMessage = 'Event is added';
            }
        })
    }

    ngOnInit() {
        let eventId = Number.parseInt(this.route.snapshot.paramMap.get('id'));
        this.eventService.getEvent(eventId).then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 1) {
                this.event = result.data as Event;
            }
        });
    }

    onCommentSent() {
        this.eventService.getComments(this.event.id).then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 1) {
                this.event.eventComments = result.data as Array<EventComment>;
            }
        });
    }

}
