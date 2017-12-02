import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Order } from '../../models/Order';
import { OrderService } from '../../services/order.service';
import { RequestResult } from '../../models/RequestResult';

@Component({
    selector: 'orders',
    templateUrl: './orders.component.html',
    styleUrls: ['./orders.component.scss']
})

export class OrdersComponent {
    constructor(
        private orderService: OrderService
    ) { }

    @Input() orders: Array<Order>;
    @Output() onPaid = new EventEmitter<number>();
    @Output() onCancel = new EventEmitter<number>();

    pay(orderId: number) {
        this.orderService.pay(orderId).then(result => {
            if (result.state == 1) {
                this.onPaid.emit(orderId);
            }
        });
    }

    cancel(orderId: number) {
        this.orderService.cancel(orderId).then(result => {
            if (result.state == 1) {
                this.onCancel.emit(orderId);
            }
        });
    }
}
