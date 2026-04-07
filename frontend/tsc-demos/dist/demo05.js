"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class Person {
    constructor(name, age, nationality = 'Indian') {
        this.name = name;
        this.age = age;
        this.nationality = nationality;
    }
    work() {
        console.log(`${this.name} is working`);
    }
}
//# sourceMappingURL=demo05.js.map