//complex types


//no new type is generated
type Name={
    firstName:string,
    middleName?:string, //optional
    lastName:string
}

type Person={
    name:Name | string,
    age:number,
    email?: string,
    social?: Record<string,string> 
}


type OrgInfo={
    id: number|string,
    salary: number
}

type Employee = Person & OrgInfo ; //combine both


var e1: Employee={
    name: {firstName:"Sanjay", middleName:"B", lastName:"Mall"},
    age:50,
    id: "e1",
    salary:50000
}

let e2: Employee={
    name:"Prabhat",
    age:40,
    id:12,
    salary:50000,
    social:{
        x:"@prabhat",
        email:"prabhat@gmail.com"
    }
}

var e3: Employee={
    name:{ firstName:"Sanjay",  lastName:"Mall"},
    age:50,
    id: "e1",
    salary:50000
}
