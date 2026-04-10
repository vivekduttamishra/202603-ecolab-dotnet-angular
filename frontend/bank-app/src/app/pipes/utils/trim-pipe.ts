import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'trim',
})
export class TrimPipe implements PipeTransform {
  transform(value: string, max:number=20, ...args: unknown[]): string {

    if(value.length<=max)
       return value;


    return value.substring(0,max)+"...";
  }
}
