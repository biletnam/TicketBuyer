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
var event_service_1 = require("../../services/event.service");
var router_1 = require("@angular/router");
var ViewEventComponent = (function () {
    function ViewEventComponent(eventService, route) {
        this.eventService = eventService;
        this.route = route;
    }
    ViewEventComponent.prototype.ngOnInit = function () {
        var _this = this;
        var eventId = Number.parseInt(this.route.snapshot.paramMap.get('id'));
        this.eventService.getEvent(eventId).then(function (response) {
            var result = response.json();
            if (result.state == 1) {
                _this.event = result.data;
            }
        });
    };
    ViewEventComponent.prototype.onCommentSent = function () {
        var _this = this;
        this.eventService.getComments(this.event.id).then(function (response) {
            var result = response.json();
            if (result.state == 1) {
                _this.event.eventComments = result.data;
            }
        });
    };
    return ViewEventComponent;
}());
ViewEventComponent = __decorate([
    core_1.Component({
        selector: 'view-event',
        templateUrl: './view-event.component.html',
        styleUrls: ['./view-event.component.scss']
    }),
    __metadata("design:paramtypes", [event_service_1.EventService,
        router_1.ActivatedRoute])
], ViewEventComponent);
exports.ViewEventComponent = ViewEventComponent;
//# sourceMappingURL=view-event.component.js.map