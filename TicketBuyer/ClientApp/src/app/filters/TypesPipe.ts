import { PipeTransform, Pipe } from '@angular/core';

@Pipe({
    name: 'types'
})
export class TypesPipe implements  PipeTransform {
    transform(value) {
        let types = [];
        for (let type in value) {
            types.push({key: type, value: value[type]});
        }
        return types;
    }
}
