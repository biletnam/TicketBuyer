import { Component, OnInit } from '@angular/core';
import { PlaceService } from '../../services/place.service';;
import { RequestResult } from '../../models/RequestResult';
import { Place } from '../../models/Place';

@Component({
    selector: 'places',
    templateUrl: './places.component.html',
    styleUrls: ['./places.component.scss']
})
export class PlacesComponent implements OnInit {
    private places: Array<Place>;

    constructor(
        private placeService: PlaceService
    ) { }

    ngOnInit() {
        this.placeService.getPlaces().then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 1) {
                this.places = result.data as Array<Place>;
            }
        });
    }
}
