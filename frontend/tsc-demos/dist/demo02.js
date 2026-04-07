"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
let a = 20; //a is explcitly declared number with value 20
let b; //b can hold a number currently not holding anythin
let c = "hello"; //c is detected as string based on assignment
let d; //since no type is assigned it is assumed to be any
let e = "Hi"; //e can refer to anything. currently referring to string
console.log(e.toLowerCase()); //any allows direct access.
let f = "Hi";
if (typeof (f) === 'string') //since we know it is string
    console.log(f.toLowerCase()); //it is allowed
//# sourceMappingURL=demo02.js.map