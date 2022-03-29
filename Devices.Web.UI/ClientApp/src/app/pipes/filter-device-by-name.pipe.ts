import { Pipe, PipeTransform } from '@angular/core';
import { Device } from '../view_models/device';

@Pipe({
  name: 'filterDeviceByName'
})
export class FilterDeviceByNamePipe implements PipeTransform {

  transform(value: Device[], input: string): Device[] {
    if (input) {
      return value.filter(d => d.name.toLowerCase().includes(input.toLocaleLowerCase()));
    } else {
      return value;
    }
  }

}
