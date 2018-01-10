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
var PlaceService = (function () {
    function PlaceService(http) {
        this.http = http;
    }
    PlaceService.prototype.getPlaces = function () {
        return this.http.get('api/Place/GetPlaces').toPromise();
    };
    PlaceService.prototype.getPlace = function (placeId) {
        var requestParams = new http_1.URLSearchParams();
        requestParams.append('placeId', placeId.toString());
        return this.http.get('api/Place/GetPlace', { params: requestParams }).toPromise();
    };
    PlaceService.prototype.getSectorTypes = function () {
        return this.http.get('api/Place/GetSectorTypes').toPromise();
    };
    PlaceService.prototype.addPlace = function (title, information, address, sectors) {
        return this.http.post('api/Place/AddPlace', {
            Name: title,
            Address: address,
            Information: information,
            Sectors: sectors.map(function (sector) { return ({
                Title: sector.title,
                TypeId: sector.type,
                Limit: sector.limit,
                Seatings: sector.type == 2 ? sector.seatings.map(function (seating) { return ({
                    Row: seating.row,
                    SeatsCount: seating.seatsCount
                }); }) : null
            }); })
        })
            .toPromise();
    };
    return PlaceService;
}());
PlaceService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], PlaceService);
exports.PlaceService = PlaceService;
//# sourceMappingURL=place.service.js.map