import { Component, effect, input, output, signal } from "@angular/core";

export interface ChangeInfo{
    direction:number,
    original:number,
    updated:number,
    
} 


@Component({
    selector: 'util-range',
    template: `
        <div >
                <button 
                    (click)="handleChange(-1)"
                    [disabled]="value()===min()"
                >⬇️</button>
                <span  >
                    {{value()}}
                </span>
                <button 
                    (click)="handleChange(1)"
                    [disabled]="value()===max()"
                >⬆️</button>
            </div>
    
    `,
    styles: `
        div{
           display:flex;
           max-width:100px;
           justify-content: space-between;
           align-items: center;
           font-size:18px;
           
        }
        button{
            border:0px;
            background-color: transparent;
        }
       
    
    `
})
export class Range {

    
    min=input(0)
    max=input(100)
    delta=input(1)
    
    change= output<ChangeInfo>()
    
    value=input<number>(0)  //input value
    
    valueChange=output<number>()
    
   

    handleChange(direction:number){
        var newValue = this.value()+direction*this.delta()
        console.log('proposed new value', newValue)
        if(newValue<this.min())
            newValue=this.min()
        else if(newValue>this.max())
            newValue= this.max()

        if(newValue!=this.value()){
            //this.value.set(newValue)
         
            //send this info to parent
            this.change.emit({
                direction,
                original: this.value(),
                updated: newValue
            })

            this.valueChange.emit(newValue)

            

        }
            
    }
}