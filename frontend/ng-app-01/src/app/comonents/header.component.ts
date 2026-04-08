import { Component, input,  signal } from "@angular/core";
import { Clock } from "./clock.component";
import { Naivator } from "./navigator.component";
import { Memebers } from "./members.component";
import { Likes } from "./likes.component";


@Component({
    standalone: true, //not part of module
    selector: 'app-header',
    templateUrl:'./header.component.html',
    styleUrl: './header.component.css'
    ,
    imports: [Clock, Naivator, Memebers, Likes]
})
export class Header {
   
    title= input('Site Title')  //user will provide this
}