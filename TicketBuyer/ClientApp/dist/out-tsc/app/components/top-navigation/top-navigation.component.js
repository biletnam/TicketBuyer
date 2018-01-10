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
var auth_service_1 = require("../../services/auth.service");
var TopNavigationComponent = (function () {
    function TopNavigationComponent(authService) {
        this.authService = authService;
    }
    TopNavigationComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.authService.getCurrentUser().then(function (response) {
            var result = response.json();
            if (result.state == 1) {
                _this.user = result.data;
            }
            _this.links = [
                { href: 'main', title: 'Main', show: true },
                { href: 'sign-in', title: 'Sign in', show: _this.user == undefined },
                { href: 'profile', title: 'My Profile', show: _this.user != undefined },
                { href: 'places', title: 'Places', show: true },
                { href: 'add-event', title: 'Add Event', show: _this.user && _this.user.role == 3 },
                { href: 'add-place', title: 'Add Place', show: _this.user && _this.user.role == 3 },
                { href: 'about', title: 'About us', show: true },
                { href: 'logout', title: 'Log out', show: _this.user != undefined }
            ];
        });
    };
    return TopNavigationComponent;
}());
TopNavigationComponent = __decorate([
    core_1.Component({
        selector: 'top-navigation',
        templateUrl: './top-navigation.component.html',
        styleUrls: ['./top-navigation.component.scss']
    }),
    __metadata("design:paramtypes", [auth_service_1.AuthService])
], TopNavigationComponent);
exports.TopNavigationComponent = TopNavigationComponent;
//# sourceMappingURL=top-navigation.component.js.map