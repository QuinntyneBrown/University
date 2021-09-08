import { Pipe, PipeTransform } from '@angular/core';
import { Cellphone, Student } from '@api';

@Pipe({
    name: 'phoneFilter',
    pure: false
})
export class PhoneFilterPipe implements PipeTransform {
    transform(items: Student[], filter: Cellphone): any {
        if (!items || !filter) {
            return items;
        }

        return items.filter(item => item.cellphone.phoneId == filter.phoneId);
    }
}
