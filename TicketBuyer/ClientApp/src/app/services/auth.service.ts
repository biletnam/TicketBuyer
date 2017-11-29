import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { RequestResult } from '../models/RequestResult';
import { SignInUser } from '../models/SignInUser';
import { SignUpUser } from '../models/SignUpUser';

@Injectable()
export class AuthService {
    private tokenKey = "token";
    private token: string;

    constructor(
        private http: Http
    ) { }

    login(email: string, password: string): Promise<RequestResult> {
        return this.http.post("api/Auth/Login", { Email: email, Password: password }).toPromise()
            .then(response => {
                let result = response.json() as RequestResult;
                if (result.state == 1) {
                }

                return result;
            });
    }

    register(email: string, password: string, username: string): Promise<RequestResult> {
        return this.http
            .post("api/Auth/Register", { Username: username, Email: email, Password: password })
            .toPromise()
            .then(response => {
                let result = response.json() as RequestResult;
                if (result.state == 1) {

                }
                return result;
            });
    }
}
