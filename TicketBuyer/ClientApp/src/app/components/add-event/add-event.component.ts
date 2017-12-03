import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EventFiltersData } from '../../models/EventFiltersData';
import { RequestResult } from '../../models/RequestResult';
import { EventService } from '../../services/event.service';

@Component({
    selector: 'add-event',
    templateUrl: './add-event.component.html',
    styleUrls: ['./add-event.component.scss']
})

export class AddEventComponent implements OnInit {
    private form: FormGroup;
    private eventFiltersData: EventFiltersData;
    private errorMessage: string;

    constructor(
        private eventService: EventService,
        private formBuilder: FormBuilder,
        private router: Router
    )
    { }

    ngOnInit() {
        this.form = this.formBuilder.group({
            title: ['', Validators.required],
            information: ['', Validators.required],
            datetime: ['', Validators.required],
            type: ['', Validators.required],
            placeId: ['', Validators.required]
        });

        this.eventService.getEventFiltersData().then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 1) {
                this.eventFiltersData = result.data as EventFiltersData;
            } else {
                this.errorMessage = result.message;
            }
        });
    }

    onSubmit() {
        this.eventService.addEvent(this.form.get('title').value,
            this.form.get('information').value,
            this.form.get('datetime').value,
            this.form.get('type').value,
            this.form.get('placeId').value).then(response => {
                let result = response.json() as RequestResult;
            if (result.state == 1) {
                this.router.navigate(["/main"]);
            } else {
                this.errorMessage = result.message;
            }
        });
    }
}
