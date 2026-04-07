



let numbers: number[] = [2,3, 9, 12];

function sum( ...numbers:number[]):number{

    let sum = 0;   //implied number

    for(let number of numbers)
        sum+=number;

    return sum;
}


//sum("a","b"); //error since string is not assignable to number

let result = sum(2,3);

console.log('result',result);
