

function sum(...numbers:number[]){
    let sum=0;
    for(let number of numbers){
        sum+=number;
    }
 
    return sum;
}

let result =sum(1,2,3,4);

console.log(`result is ${result}`)
