

function * generate(){
    console.log("reached first yeild")
    yield "red"
    console.log("reached second yield")
    yield "green"
    console.log("reached third yield")
    yield "blue"
    console.log("end")
}

let g = generate(); //returns a generator. 

console.log('g',g); 

let result=g.next()

while(!result.done){
    console.log(result.value)
    result=g.next()
}

//we can also use for-of loop

console.log('for-of loop')

//automatically creates generator and result using gen.next()
for(let value of generate())
    console.log(value); 






