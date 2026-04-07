"use strict";
//complex types
Object.defineProperty(exports, "__esModule", { value: true });
//no new type is generated
let p = {
    name: 'Sanjay',
    age: 50
};
console.log('p', p);
p.age = 51; //can change existing info
p.email = "sanjay@gmail.com"; //can't add new info the way we can in JS
console.log('p', p);
//# sourceMappingURL=demo07.js.map