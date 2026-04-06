function showPerson(person) {
    console.log(`Person name=${person.name}\tage=${person.age}`);
}


//create person 1
let p1 = new Object();
//p1 is created but we don't know what is p1
//we can add properties (and behaviors) after creating p
p1.name="Sanjay";
p1.age=50;
showPerson(p1);


//create person 2
let p2 = {}    //same as new Object()
p2.name="Shivanshi";
p2.age=20;
showPerson(p2);


//create person 3
let p3 = {
    name: 'Shweta',
    age:40
}

showPerson(p3);


//create person 4
let p4 = {
    name:"Aman"
};

p4.age = 50;

p4["email"]="aman@gmail.com";

console.log('p4',p4);

console.log('p4["name"]',p4["name"]);
console.log('p4["age"]',p4["age"]);
console.log('p4.email',p4.email);

console.log('"email" in p1',"email" in p1);
console.log('"email" in p4',"email" in p4);


console.log('p1.email',p1.email);

for(let x in p4)
    console.log(x, p4[x]);
