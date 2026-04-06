

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


var promise = factorial(5);


promise
    .then(result=> console.log(`Factorial is ${result}`))
    .catch(error=>console.log(`Error : ${error.message}`))