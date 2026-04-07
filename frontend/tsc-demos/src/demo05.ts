


class Person{
   

    constructor(private name:string, 
                private age:number, 
                private nationality:string='Indian'){
        
    }

    work(){
        console.log(`${this.name} is working`); 
    }
}

