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
var EventService = (function () {
    function EventService(http) {
        this.http = http;
    }
    EventService.prototype.getEventFiltersData = function () {
        return this.http.get('api/Event/GetEventFiltersData').toPromise();
    };
    EventService.prototype.addEvent = function (title, information, datetime, type, placeId) {
        return this.http.post('api/Event/AddEvent', {
            Name: title,
            DateTime: datetime,
            Type: type,
            Information: information,
            PlaceId: placeId
        }).toPromise();
    };
    EventService.prototype.getEvents = function (eventFilter) {
        var requestParams = new http_1.URLSearchParams();
        requestParams.append('type', eventFilter.type && eventFilter.type.toString());
        requestParams.append('status', eventFilter.status && eventFilter.status.toString());
        requestParams.append('startDate', eventFilter.startDate && eventFilter.startDate.toString());
        requestParams.append('endDate', eventFilter.endDate && eventFilter.endDate.toString());
        requestParams.append('placeId', eventFilter.placeId && eventFilter.placeId.toString());
        return this.http.get('api/Event/GetEvents', { params: requestParams }).toPromise();
    };
    EventService.prototype.getEvent = function (eventId) {
        var requestParams = new http_1.URLSearchParams();
        requestParams.append('eventId', eventId.toString());
        return this.http.get('api/Event/GetEvent', { params: requestParams }).toPromise();
    };
    EventService.prototype.sendComment = function (comment, eventId) {
        return this.http.post('api/EventComment/AddComment', { comment: comment, eventId: eventId }).toPromise();
    };
    EventService.prototype.getComments = function (eventId) {
        var requestParams = new http_1.URLSearchParams();
        requestParams.append('eventId', eventId.toString());
        return this.http.get('api/EventComment/GetComments', { params: requestParams }).toPromise();
    };
    return EventService;
}());
EventService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], EventService);
exports.EventService = EventService;
//# sourceMappingURL=event.service.js.map