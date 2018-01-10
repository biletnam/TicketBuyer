import { Component, OnInit } from '@angular/core';
import { PlaceService } from '../../services/place.service';
import { Place } from '../../models/Place';
import { ActivatedRoute } from '@angular/router';
import { RequestResult } from '../../models/RequestResult';

@Component({
    selector: 'view-place',
    templateUrl: './view-place.component.html',
    styleUrls: ['./view-place.component.scss']
})

export class ViewPlaceComponent implements OnInit {
    private place: Place;
    private sectorTypes: { [key: number]: string };

    constructor(
        private placeService: PlaceService,
        private route: ActivatedRoute

    ) { }

    ngOnInit() {
        let placeId = Number.parseInt(this.route.snapshot.paramMap.get('id'));
        this.placeService.getSectorTypes().then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 1) {
                this.sectorTypes = result.data as { [key: number]: string };

                this.placeService.getPlace(placeId).then(response => {
                    let result = response.json() as RequestResult;
                    if (result.state == 1) {
                        this.place = result.data as Place;
                    }
                });
            }
        });
    }
}



