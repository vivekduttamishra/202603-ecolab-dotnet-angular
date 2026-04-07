"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function sum(...numbers) {
    let sum = 0;
    for (let number of numbers) {
        sum += number;
    }
    return sum;
}
let result = sum(1, 2, 3, 4);
console.log(`result is ${result}`);
//# sourceMappingURL=demo04.js.map