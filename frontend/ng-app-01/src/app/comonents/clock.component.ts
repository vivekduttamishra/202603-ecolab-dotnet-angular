import { Component, effect, signal } from "@angular/core";


@Component({
    selector:"util-clock",
    template:`<span class='clock'>{{time.toLocaleTimeString()}}</span>`

})
export class Clock
{
    //time=signal(new Date())
    time=new Date()

    constructor(){
        setInterval(()=>{
           //this.time.set(new Date())
           this.time=new Date()
        }, 1000)
    }   

}