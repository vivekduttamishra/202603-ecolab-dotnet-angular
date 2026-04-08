import { Component, signal } from "@angular/core";
import { Header } from "./comonents/header.component";
import { HomeScreen } from "./comonents/home-screen.component";
import { Likes } from "./comonents/likes.component";

@Component({
    selector: "the-bank",

    template: `
        <div>
            <app-header></app-header>
            <app-likes></app-likes>
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
   imports: [Header, HomeScreen, Likes]

})
export class App {
    title='IDFC Bank'
    likes=0

    incrementLike(){
        this.likes++;
    }
}