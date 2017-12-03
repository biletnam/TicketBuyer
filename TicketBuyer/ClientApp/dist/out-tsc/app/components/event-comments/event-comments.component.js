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
var forms_1 = require("@angular/forms");
var EventCommentsComponent = (function () {
    function EventCommentsComponent(eventService, formBuilder) {
        this.eventService = eventService;
        this.formBuilder = formBuilder;
        this.onCommentSent = new core_1.EventEmitter();
    }
    EventCommentsComponent.prototype.ngOnInit = function () {
        this.form = this.formBuilder.group({
            comment: ['', forms_1.Validators.required]
        });
    };
    EventCommentsComponent.prototype.onSubmit = function () {
        var _this = this;
        this.eventService.sendComment(this.form.get('comment').value, this.eventId).then(function (response) {
            var result = response.json();
            if (result.state == 1) {
                _this.onCommentSent.emit();
            }
        });
    };
    return EventCommentsComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], EventCommentsComponent.prototype, "eventComments", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Number)
], EventCommentsComponent.prototype, "eventId", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], EventCommentsComponent.prototype, "onCommentSent", void 0);
EventCommentsComponent = __decorate([
    core_1.Component({
        selector: 'event-comments',
        templateUrl: './event-comments.component.html',
        styleUrls: ['./event-comments.component.scss']
    }),
    __metadata("design:paramtypes", [event_service_1.EventService,
        forms_1.FormBuilder])
], EventCommentsComponent);
exports.EventCommentsComponent = EventCommentsComponent;
//# sourceMappingURL=event-comments.component.js.map