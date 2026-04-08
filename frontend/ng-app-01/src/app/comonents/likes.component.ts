import { Component, signal } from "@angular/core";
import { NgIf } from "../../../node_modules/@angular/common/types/_common_module-chunk";

@Component({
    standalone:true,
    selector:'app-likes',
    template:`
     <p> 
       <span class='heart' (click)="handleLike()" >
            {{liked()?filled:empty}}
        </span> 
       {{likes()}}
    
     </p>
     
    `,
    styles:`
    
        p{
            
            margin-left:10px;
            margin-right:10px;
            margin-top:25%;
        }
        .heart{
            cursor:pointer;
        }
    
    `
   
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
        let delta = this.liked()? -1 : 1

        this.likes.set(this.likes()+delta)
        this.liked.set(!this.liked())
    }

    fakeLikes(){
        setInterval(()=>{
            const newLikes = Math.floor(Math.random()*6)-2
            
            this.likes.set(this.likes() + newLikes)

        },1000)
    }

}