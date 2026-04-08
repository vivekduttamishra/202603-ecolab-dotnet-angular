import { Component, signal } from "@angular/core";
import { Header } from "./comonents/header.component";
import { HomeScreen } from "./comonents/home-screen.component";
import { Likes } from "./comonents/likes.component";
import { Feedback } from "./comonents/feedback.component";
import { Clock } from "./comonents/clock.component";
import { testComponent } from "./comonents/test.component";

@Component({
    selector: "the-bank",

    template: `
        <div>
            
            <app-header title={{title}}  ></app-header>
            <div class='screen'>
                <home-screen></home-screen>
            </div>
        </div>
        
        `,

   styles: `
   .screen{
    margin:10px;
   }

   `,
   imports: [Header, HomeScreen,  testComponent]

})
export class App {
    title='The Bank'
    
}