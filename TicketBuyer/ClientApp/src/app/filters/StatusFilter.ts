import { Pipe, PipeTransform } from '@angular/core';
import { OrderStatus } from '../enums/OrderStatus';
@Pipe({
    name: 'statusFilter'
})

export class StatusFilter implements  PipeTransform {
    transform(items: any[], filter: string) {
        if (!items || !filter) {
            return items;
        }

        return items.filter(i => i.status == OrderStatus[filter] + 1);
    }
}
