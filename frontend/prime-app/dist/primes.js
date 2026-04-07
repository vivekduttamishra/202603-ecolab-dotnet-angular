"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function isPrime(number) {
    if (number < 2)
        return false;
    for (let i = 2; i < number; i++)
        if (number % i == 0)
            return false;
    return true;
}
function findPrimesSync(min, max) {
    if (min >= max)
        throw new Error(`Invalid Range ${min}-${max}`);
    let result = [];
    for (let i = min; i < max; i++)
        if (isPrime(i))
            result.push(i);
    return result;
}
//# sourceMappingURL=primes.js.map