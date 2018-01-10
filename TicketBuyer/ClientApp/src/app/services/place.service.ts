import {Injectable} from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';
import { Sector } from '../models/Sector';

@Injectable()
export class PlaceService {
    constructor(
        private http: Http
    ) { }

    getPlaces() {
        return this.http.get('api/Place/GetPlaces').toPromise();
    }

    getPlace(placeId: number) {
        let requestParams = new URLSearchParams();
        requestParams.append('placeId', placeId.toString());

        return this.http.get('api/Place/GetPlace', { params: requestParams }).toPromise();
    }

    getSectorTypes() {
        return this.http.get('api/Place/GetSectorTypes').toPromise();
    }

    addPlace(title: string, information: string, address: string, sectors: Array<Sector>) {
        return this.http.post('api/Place/AddPlace',
            {
                Name: title,
                Address: address,
                Information: information,
                Sectors: sectors.map(sector => ({
                    Title: sector.title,
                    TypeId: sector.type,
                    Limit: sector.limit,
                    Seatings: sector.type == 2 ? sector.seatings.map(seating => ({
                        Row: seating.row,
                        SeatsCount: seating.seatsCount
                    })) : null
                }))
            })
            .toPromise();
    }
}
