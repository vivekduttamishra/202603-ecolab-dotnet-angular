

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

// function didn't start executing the body
//no console.log

//let's get the values

console.log('g.next()',g.next()); //code executed till first yield.it says not finished yet

console.log('g.next()',g.next()); //reaches second yield. it says not finished yet

console.log('g.next()',g.next()); //reached third yield. this is the last one. but it doesn't known it.

console.log('g.next()',g.next());  //reaches end of function. realises no more yiled (data) left.







