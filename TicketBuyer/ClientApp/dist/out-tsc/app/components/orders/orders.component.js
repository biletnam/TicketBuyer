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
var order_service_1 = require("../../services/order.service");
var OrdersComponent = (function () {
    function OrdersComponent(orderService) {
        this.orderService = orderService;
        this.onPaid = new core_1.EventEmitter();
        this.onCancel = new core_1.EventEmitter();
    }
    OrdersComponent.prototype.pay = function (orderId) {
        var _this = this;
        this.orderService.pay(orderId).then(function (result) {
            if (result.state == 1) {
                _this.onPaid.emit(orderId);
            }
        });
    };
    OrdersComponent.prototype.cancel = function (orderId) {
        var _this = this;
        this.orderService.cancel(orderId).then(function (result) {
            if (result.state == 1) {
                _this.onCancel.emit(orderId);
            }
        });
    };
    return OrdersComponent;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], OrdersComponent.prototype, "orders", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], OrdersComponent.prototype, "onPaid", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], OrdersComponent.prototype, "onCancel", void 0);
OrdersComponent = __decorate([
    core_1.Component({
        selector: 'orders',
        templateUrl: './orders.component.html',
        styleUrls: ['./orders.component.scss']
    }),
    __metadata("design:paramtypes", [order_service_1.OrderService])
], OrdersComponent);
exports.OrdersComponent = OrdersComponent;
//# sourceMappingURL=orders.component.js.map