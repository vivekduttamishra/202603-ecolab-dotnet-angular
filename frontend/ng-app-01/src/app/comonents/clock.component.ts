import { Component, effect, signal } from "@angular/core";


@Component({
    selector: "util-clock",
    template: `<span class='clock'>{{time.toLocaleTimeString()}}</span>`

})
export class Clock {
    //time=signal(new Date())
    time = new Date()

    constructor() {
        console.log('clock created...')

       

        effect(cleanup => {
            console.log(`component init/update`)
            const iid = setInterval(() => {
                this.time = new Date();
                console.log(iid, 'clock executed')
            }, 1000)


            //describe how to cleanup
            cleanup(() => {
                console.log('component cleaned')
                clearInterval(iid)
            })
        })

    }

    iid?: number;



}