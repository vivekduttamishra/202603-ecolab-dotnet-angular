

function factorial(n)
{

    return new Promise((resolve,reject)=>{
        
        if(n<0)
            return reject(new Error('Number must not be negative'))

        let fn=1
        while(n)
        {
            fn*=n--;
        }

        return resolve(fn);

    });

}

async function printFactorial(n)
{
    try{
        var result = await factorial(n);
        //when resolved
        console.log(`Factorail of ${n} = ${result}`)
    }catch(err){
        console.log(`Error calcualting factorial of ${n}: ${err.message}`)
    }
}

printFactorial(7)
printFactorial(-1)