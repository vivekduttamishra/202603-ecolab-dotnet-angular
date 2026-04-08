import { Component, signal } from "@angular/core";
import { NgIf } from "../../../node_modules/@angular/common/types/_common_module-chunk";

@Component({
    standalone:true,
    selector:'app-likes',
    template:`
     <p> 
        {{likes()}} Likes 
       
        @if(!liked()){
            <button (click)="handleLike()"> Like Us </button>
        }
    
     </p>
     
    `,
   
})
export class Likes{

    likes=signal(0)
    liked=signal(false)
    empty="🤍"
    filled="❤️"

    constructor(){
        this.fakeLikes();
    }

    handleLike(){
        this.likes.set(this.likes()+1)
        this.liked.set(true)
    }

    fakeLikes(){
        setInterval(()=>{
            const newLikes = Math.floor(Math.random()*3)+3
            
            this.likes.set(this.likes() + newLikes)

        },2000)
    }

}