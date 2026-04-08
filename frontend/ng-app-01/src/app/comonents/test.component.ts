import { Component, signal } from "@angular/core";
import { Clock } from "./clock.component";
import { Feedback } from "./feedback.component";

@Component({
    selector:'app-test',
    template:`
     <button class="btn btn-sm btn-primary"
                        (click)="toggleClock()"
                    >{{hidden()?'Show':'Hide'}} Clock</button>
                    <util-clock 
                        [hidden]='hidden()'
                    ></util-clock>
           
            <app-feedback></app-feedback>
    `,
    imports: [Clock, Feedback]
})
export class testComponent{
    likes=0

    incrementLike(){
        this.likes++;
    }

    hidden=signal(false)

    toggleClock(){
        this.hidden.set(!this.hidden())
    }
}