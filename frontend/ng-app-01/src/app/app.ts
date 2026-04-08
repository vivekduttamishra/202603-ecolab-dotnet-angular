import { Component, signal } from "@angular/core";
import { Header } from "./comonents/header.component";
import { HomeScreen } from "./comonents/home-screen.component";
import { Likes } from "./comonents/likes.component";
import { Feedback } from "./comonents/feedback.component";

@Component({
    selector: "the-bank",

    template: `
        <div>
            <app-header></app-header>
            <app-likes></app-likes>
            <app-feedback></app-feedback>
            <home-screen></home-screen>
        </div>
        
        `,

   styles: `
    h1{
        color: cadetblue;
    }

    p{
        color:cadetblue;
    }

   `,
   imports: [Header, HomeScreen, Likes, Feedback]

})
export class App {
    title='IDFC Bank'
    likes=0

    incrementLike(){
        this.likes++;
    }
}