import { Component, effect, signal } from "@angular/core";


@Component({
    selector:"util-clock-v2",
    template:`<span class='clock'>{{time.toLocaleTimeString()}}</span>`

})
export class Clock
{
    //time=signal(new Date())
    time=new Date()

    constructor(){
        console.log('clock created...')
    }

    iid?:number;

    ngOnInit(){
        this.iid=setInterval(()=>{
            //this.time.set(new Date())
            this.time=new Date()
            console.log(this.iid,"clock executed")
        }, 1000)
        console.log('clock initialized with interval id ',this.iid)
    }   

    ngOnDestroy(){
        console.log('clock destroyed ', this.iid)
        clearInterval(this.iid)
    }

}