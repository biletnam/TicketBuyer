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
var EventFilter_1 = require("../../models/EventFilter");
var EventsComponent = (function () {
    function EventsComponent(eventService) {
        this.eventService = eventService;
    }
    EventsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.eventFilter = new EventFilter_1.EventFilter();
        this.eventFilter.type = null;
        this.eventFilter.status = null;
        this.eventFilter.startDate = null;
        this.eventFilter.endDate = null;
        this.eventFilter.placeId = null;
        this.eventService.getEventFiltersData().then(function (response) {
            var result = response.json();
            if (result.state == 1) {
                _this.eventFiltersData = result.data;
            }
        });
        this.eventService.getEvents(this.eventFilter).then(function (response) {
            var result = response.json();
            if (result.state == 1) {
                _this.events = result.data;
            }
        });
    };
    EventsComponent.prototype.onClick = function () {
        var _this = this;
        this.eventService.getEvents(this.eventFilter).then(function (response) {
            var result = response.json();
            if (result.state == 1) {
                _this.events = result.data;
            }
        });
    };
    return EventsComponent;
}());
EventsComponent = __decorate([
    core_1.Component({
        selector: 'events',
        templateUrl: './events.component.html',
        styleUrls: ['./events.component.scss']
    }),
    __metadata("design:paramtypes", [event_service_1.EventService])
], EventsComponent);
exports.EventsComponent = EventsComponent;
//# sourceMappingURL=events.component.js.map