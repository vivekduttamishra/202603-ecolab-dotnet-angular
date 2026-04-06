
function eat(person, food){
    console.log(`${person.name} eats ${food}`)
}

var sanjay = {
    name:'Sanjay',
    eat:eat
}

var prabhat={
    name:'Prabhat'
}
prabhat.eat=eat;


sanjay.eat(prabhat, "Dinner");