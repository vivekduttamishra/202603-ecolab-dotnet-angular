
function isPrime(n) {
    if (n < 2)
        return false

    for (let i = 2; i < n; i++)
        if (n % i === 0)
            return false;

    return true
}

function findPrimes(min, max)
{
    return new Promise((resolve,reject)=>{

        if (min >= max)
            return reject( new Error(`Invalid Range ${min}-${max}`)) //rejected
    
        let primes = [];
        for (let i = min; i < max; i++) {
            if (isPrime(i))
                primes.push(i)
        }
    
        return resolve(primes) 
    })

}

async function printPrimeCount(min,max){

    try{
        console.log(`Finding primes between ${min}-${max}.`)
        var primes = await findPrimes(min,max);
        console.log(primes.length)
        
    }catch(error)
    {
        console.log(error.message);
    }
}

printPrimeCount(2,500000)
printPrimeCount(100,2)
printPrimeCount(2,5000)

