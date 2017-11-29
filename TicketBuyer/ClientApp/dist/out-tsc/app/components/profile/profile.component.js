"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var ProfileComponent = (function () {
    function ProfileComponent() {
        this.title = 'Profile';
        this.albums = ['All', 'Nature', 'People'];
        this.images = [
            'http://luxfon.com/images/201302/luxfon.com_19801.jpg',
            'http://media-cache-ec0.pinimg.com/736x/c3/10/22/c3102281f88237e7a2515099d2e6651f.jpg',
            'http://media-cache-ak0.pinimg.com/736x/2e/7f/db/2e7fdb7ed765973407fed0b0141bb126.jpg',
            'http://media-cache-ec0.pinimg.com/600x/97/35/91/97359142dce582b4530cb0f23fbe2e43.jpg'
        ];
    }
    return ProfileComponent;
}());
ProfileComponent = __decorate([
    core_1.Component({
        selector: 'profile',
        templateUrl: './profile.component.html',
        styleUrls: ['./profile.component.scss']
    })
], ProfileComponent);
exports.ProfileComponent = ProfileComponent;
//# sourceMappingURL=profile.component.js.map