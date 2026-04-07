import { Component, signal } from "@angular/core";
import { Clock } from "./comonents/clock.component";

@Component({
    selector: "the-bank",

    template: `
        <h1>{{title}}</h1>
        <util-clock></util-clock>
        <p>Welcome to The Bank—the only bank you need to bank with.</p>
        <button (click)="incrementLike()" >{{likes}} likes</button>
        `,

   styles: `
    h1{
        color: cadetblue;
    }

    p{
        color:cadetblue;
    }

   `,
   imports: [Clock]

})
export class App {
    title='IDFC Bank'
    likes=0

    incrementLike(){
        this.likes++;
    }
}