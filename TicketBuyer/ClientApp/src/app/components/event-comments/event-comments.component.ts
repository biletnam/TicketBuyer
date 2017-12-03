import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { EventService } from '../../services/event.service';
import { EventComment } from '../../models/EventComment';
import { RequestResult } from '../../models/RequestResult';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
    selector: 'event-comments',
    templateUrl: './event-comments.component.html',
    styleUrls: ['./event-comments.component.scss']
})

export class EventCommentsComponent implements OnInit{
    @Input() eventComments: Array<EventComment>;
    @Input() eventId: number;
    @Output() onCommentSent = new EventEmitter();

    private form: FormGroup;

    constructor(
        private eventService: EventService,
        private formBuilder: FormBuilder
    ) {}

    ngOnInit() {
        this.form = this.formBuilder.group({
            comment: ['', Validators.required]
        });
    }

    onSubmit() {
        this.eventService.sendComment(this.form.get('comment').value, this.eventId).then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 1) {
                this.onCommentSent.emit();
            }
        });
    }
}
