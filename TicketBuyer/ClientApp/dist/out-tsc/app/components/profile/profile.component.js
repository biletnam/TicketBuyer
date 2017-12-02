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
var user_service_1 = require("../../services/user.service");
var OrderStatus_1 = require("../../enums/OrderStatus");
var ProfileComponent = (function () {
    function ProfileComponent(userService) {
        this.userService = userService;
        this.statuses = Object.keys(OrderStatus_1.OrderStatus).map(function (k) { return OrderStatus_1.OrderStatus[k]; });
    }
    ProfileComponent.prototype.ngOnInit = function () {
        var _this = this;
        var i = OrderStatus_1.OrderStatus['Wait for payment'];
        this.userService.getUserProfile().then(function (response) {
            var result = response;
            if (result.state == 1) {
                _this.userPage = result.data;
            }
        });
    };
    ProfileComponent.prototype.onPaid = function (orderId) {
        this.userPage.orders.find(function (x) { return x.id == orderId; }).status = 2;
    };
    ProfileComponent.prototype.onCancel = function (orderId) {
        this.userPage.orders.find(function (x) { return x.id == orderId; }).status = 3;
    };
    ProfileComponent.prototype.onWishRemoved = function (wishEventId) {
        this.userPage.wishEvents = this.userPage.wishEvents.filter(function (x) { return x.id !== wishEventId; });
    };
    return ProfileComponent;
}());
ProfileComponent = __decorate([
    core_1.Component({
        selector: 'profile',
        templateUrl: './profile.component.html',
        styleUrls: ['./profile.component.scss']
    }),
    __metadata("design:paramtypes", [user_service_1.UserService])
], ProfileComponent);
exports.ProfileComponent = ProfileComponent;
//# sourceMappingURL=profile.component.js.map