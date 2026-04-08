import { Component, signal } from "@angular/core";
import { NgIf } from "../../../node_modules/@angular/common/types/_common_module-chunk";

@Component({
    standalone:true,
    selector:'app-feedback',
    template:`
     <p> 
      
        <img 
            (click)='handleFeedback()' 
             
            [src]="feedback()===0?neutral:feedback()===1?happy:sad" />
        
     </p>
     
    `,
    styles:`
    
        p{
            font-size: 1.5em;
        }
        img{
            height:60px;
            cursor:pointer;
        }
    
    `
   
})
export class Feedback{

    happy="/like.jpg"
    sad='/dislike.jpg'
    neutral='/neutral.jpg'

    feedback=signal(0) //toggles between 0,1,2
    


    handleFeedback(){
        let next=  (this.feedback()+1)%3;
        this.feedback.set(next);
    }

   

}