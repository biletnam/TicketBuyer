import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { RequestResult } from '../models/RequestResult';


@Injectable()
export class OrderService {
    constructor(
        private http: Http
    ) { }

    pay(orderId: number) {
        return this.http.post('api/Order/Pay', { orderId: orderId }).toPromise().then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 0) {
                
            }

            return result;
        });
    }

    cancel(orderId: number) {
        return this.http.post('api/Order/Cancel', { orderId: orderId }).toPromise().then(response => {
            let result = response.json() as RequestResult;
            if (result.state == 0) {
                
            }

            return result;
        });
    }
}
