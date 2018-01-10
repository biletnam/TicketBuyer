import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class AboutService {

    constructor(
        private http: Http
    ) { }

    getAboutData() {
        return this.http.get('api/About').toPromise();
    }
}
