import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { RequestResult } from '../models/RequestResult';

@Injectable()
export class UserService {
    private tokenKey = "token";
    private token: string;

    constructor(
        private http: Http
    ) { }

    getUserProfile() {
        return this.http.get("api/Profile");
    }
}
