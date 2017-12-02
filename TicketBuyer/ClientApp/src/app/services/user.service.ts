import { Injectable } from '@angular/core';
import { Http, URLSearchParams  } from '@angular/http';
import { RequestResult } from '../models/RequestResult';

@Injectable()
export class UserService {
    private tokenKey = "token";
    private token: string;

    constructor(
        private http: Http
    ) { }

    getUserProfile() {
        return this.http.get("api/Profile").toPromise().then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 0) {
                
            }

            return result;
        });
    }

    removeWish(wishEventId) {
        let requestParams = new URLSearchParams();
        requestParams.append('wishEventId', wishEventId);

        return this.http.delete("api/Profile/RemoveWish", { params: requestParams }).toPromise().then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 0) {
                
            }

            return result;
        });
    }
}
