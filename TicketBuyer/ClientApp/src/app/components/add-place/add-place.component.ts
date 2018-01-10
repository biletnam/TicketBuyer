import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { Router } from '@angular/router';
import { RequestResult } from '../../models/RequestResult';
import { PlaceService } from '../../services/place.service';
import { Sector } from '../../models/Sector';

@Component({
    selector: 'add-place',
    templateUrl: './add-place.component.html',
    styleUrls: ['./add-place.component.scss']
})

export class AddPlaceComponent implements OnInit {
    private form: FormGroup;
    private errorMessage: string;
    private sectors: FormArray;
    private seatings: FormArray;
    private sectorTypes: { [key: number]: string };

    constructor(
        private placeService: PlaceService,
        private formBuilder: FormBuilder,
        private router: Router
    )
    { }

    ngOnInit() {
        this.placeService.getSectorTypes().then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 1) {
                this.sectorTypes = result.data as { [key: number]: string };
            }
        });

        this.form = this.formBuilder.group({
            title: ['', Validators.required],
            information: ['', Validators.required],
            address: ['', Validators.required],
            sectors: this.formBuilder.array([this.createSector()])
        });
    }

    createSector() {
        return this.formBuilder.group({
            title: ['', Validators.required],
            type: ['', Validators.required],
            limit: ['', Validators.required],
            seatings: this.formBuilder.array([this.createSeating()])
        });
    }

    addSector(): void {
        this.sectors = this.form.get('sectors') as FormArray;
        this.sectors.push(this.createSector());
    }


    createSeating() {
        return this.formBuilder.group({
            row: this.seatings != undefined ? this.seatings.length + 1 : 1,
            seatsCount: ''
        });
    }

    addRow(i: number) {
        this.sectors = this.form.get('sectors') as FormArray;
        this.seatings = this.sectors.controls[i].get('seatings') as FormArray;
        this.seatings.push(this.createSeating());
    }

    onSubmit() {
        this.placeService.addPlace(this.form.get('title').value,
            this.form.get('information').value,
            this.form.get('address').value,
            this.form.get('sectors').value
            ).then(response => {
                let result = response.json() as RequestResult;
                if (result.state == 1) {
                    this.router.navigate(["/places"]);
                } else {
                    this.errorMessage = result.message;
                }
            });
    }
}
