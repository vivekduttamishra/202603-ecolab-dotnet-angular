import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'emailEncoder',
})
export class EmailEncoderPipe implements PipeTransform {
  transform(value: string, ...args: unknown[]): unknown {
    return value.replace("@", "-at-")
  }
}
