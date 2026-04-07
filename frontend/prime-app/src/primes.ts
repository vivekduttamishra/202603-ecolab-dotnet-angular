

function isPrime(number:number){
    if(number<2)
        return false;

    for(let i=2;i<number;i++)
        if(number%i==0)
            return false;

    return true;
}


function findPrimesSync(min:number,max:number):number[]{

    if(min>=max)
        throw new Error(`Invalid Range ${min}-${max}`);
    let result:number[]=[];
    for(let i=min;i<max;i++)
        if(isPrime(i))
            result.push(i);

    return result;
}