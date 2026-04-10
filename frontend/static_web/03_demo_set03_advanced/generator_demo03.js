

function isPrime(number){
    if(number<2)
        return false

    for(let i =2 ;i<number;i++)
        if(number%i===0)
            return false

    return true;

}

function * findPrimes(min,max){

    for(let i=min;i<max;i++){
        if(isPrime(i)){
            console.log("*");
            yield i
        }
    }
}

let i=0;
for(let prime of findPrimes(1,10000)){
    i++;
    console.log(`prime#${i} = ${prime}`);
    if(i%5===0)
        break;
}

console.log('end of program')