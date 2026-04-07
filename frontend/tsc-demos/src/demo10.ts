
type Person={
    name:string,
}

type Peson={
    age:number;
}

var p = {
    name:"John",
    age:30
}

console.log('p',p);


interface Employee{
    name:string;
}

interface Employee{
    salary:number;
}

var e:Employee={
    name:"John",
    salary:50000
}

console.log('e',e);
