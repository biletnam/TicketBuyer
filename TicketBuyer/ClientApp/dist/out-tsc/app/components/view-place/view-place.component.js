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
var place_service_1 = require("../../services/place.service");
var router_1 = require("@angular/router");
var ViewPlaceComponent = (function () {
    function ViewPlaceComponent(placeService, route) {
        this.placeService = placeService;
        this.route = route;
    }
    ViewPlaceComponent.prototype.ngOnInit = function () {
        var _this = this;
        var placeId = Number.parseInt(this.route.snapshot.paramMap.get('id'));
        this.placeService.getSectorTypes().then(function (response) {
            var result = response.json();
            if (result.state == 1) {
                _this.sectorTypes = result.data;
                _this.placeService.getPlace(placeId).then(function (response) {
                    var result = response.json();
                    if (result.state == 1) {
                        _this.place = result.data;
                    }
                });
            }
        });
    };
    return ViewPlaceComponent;
}());
ViewPlaceComponent = __decorate([
    core_1.Component({
        selector: 'view-place',
        templateUrl: './view-place.component.html',
        styleUrls: ['./view-place.component.scss']
    }),
    __metadata("design:paramtypes", [place_service_1.PlaceService,
        router_1.ActivatedRoute])
], ViewPlaceComponent);
exports.ViewPlaceComponent = ViewPlaceComponent;
//# sourceMappingURL=view-place.component.js.map