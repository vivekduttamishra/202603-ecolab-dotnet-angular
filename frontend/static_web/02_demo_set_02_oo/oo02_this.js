
function eat(food){
    console.log(`${this.name} eats ${food}`)
}

var sanjay = {
    name:'Sanjay',
    eat:eat
}

var prabhat={
    name:'Prabhat'
}
prabhat.eat=eat;


sanjay.eat("Dinner");  //sanjay becomes this
prabhat.eat("Maggi"); //prabhat becomes this

var name="Mr Window";  //same as window.name in browser based. no effect in node.js

eat("Ice Cream"); //who is eating icecream?