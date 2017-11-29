"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var AuthService = (function () {
    function AuthService(http) {
        this.http = http;
        this.tokenKey = "token";
    }
    AuthService.prototype.login = function (email, password) {
        return this.http.post("api/Auth/Login", { Email: email, Password: password }).toPromise()
            .then(function (response) {
            var result = response.json();
            if (result.state == 1) {
            }
            return result;
        });
    };
    AuthService.prototype.register = function (email, password, username) {
        return this.http
            .post("api/Auth/Register", { Username: username, Email: email, Password: password })
            .toPromise()
            .then(function (response) {
            var result = response.json();
            if (result.state == 1) {
            }
            return result;
        });
    };
    return AuthService;
}());
AuthService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], AuthService);
exports.AuthService = AuthService;
//# sourceMappingURL=auth.service.js.map