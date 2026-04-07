import { Component, signal } from "@angular/core";


@Component({
    selector:"util-clock",
    template:`<span class='clock'>{{time().toLocaleTimeString()}}</span>`

})
export class Clock
{
    time=signal(new Date())

    constructor(){
        setInterval(()=>{
           this.time.set(new Date())
        }, 1000)
    }

}