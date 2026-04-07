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
function findPrimes(min, max) {
    return new Promise((resolve, reject) => {
        let low = min;
        let hi = Math.min(low + 1000, max);
        let result = [];
        let iid = setInterval(() => {
            if (min >= max) {
                clearInterval(iid);
                return reject(new Error(`Invalid Range ${min}-${max}`));
            }
            for (let i = low; i < hi; i++)
                if (isPrime(i))
                    result.push(i);
            low = hi;
            hi = Math.min(low + 1000, max);
            if (low == max) {
                //work is over
                clearInterval(iid);
                return resolve(result);
            }
        }, 1);
    });
}
const tasksUI = document.getElementById("results");
const minBox = document.getElementById("min");
const maxBox = document.getElementById("max");
minBox.value = 2;
maxBox.value = 200000;
let tasks = [];
let taskCount = 0;
clearResults();
function addTask() {
    //console.log('Calculation Started')
    let min = Number(minBox.value);
    var max = +maxBox.value; // + converts to number
    let task = {
        id: ++taskCount,
        min,
        max,
        status: "running"
    };
    tasks.push(task);
    const row = createRow(task);
    tasksUI.innerHTML += row;
    updateRow(task);
    let promise = findPrimes(task.min, task.max);
    promise
        .then(primes => {
        task.primes = primes;
        task.status = "done";
        updateRow(task);
    })
        .catch(error => {
        task.error = error.message;
        task.status = "error";
        updateRow(task);
    });
}
function show(id, visible) {
    let e = document.getElementById(id);
    if (visible)
        e.style.display = "inline";
    else
        e.style.display = "none";
}
function updateRow(task) {
    let errorId = `${task.id}-error`;
    let successId = `${task.id}-success`;
    let waitId = `${task.id}-waiting`;
    show(errorId, false);
    show(successId, false);
    show(waitId, false);
    switch (task.status) {
        case "error":
            show(errorId, true);
            document.getElementById(errorId).innerHTML = task.error;
            break;
        case "done":
            show(successId, true);
            document.getElementById(successId).innerHTML = task.primes.length.toString();
            break;
        case "running":
            show(waitId, true);
            break;
    }
}
function createRow(task) {
    return `
        <tr id="${task.id}">
            <td>
                ${task.id}
            </td>
            <td>
                ${task.min}
            </td>
            <td>
                ${task.max}
            </td>
            <td  >
                <span id="${task.id}-error" class="text-danger">
                    error
                </span>
                <span id="${task.id}-success" class="text-success">
                    25
                </span>
                <span id="${task.id}-waiting" class="text-primary">
                    <img src="images/loader07.gif" height="80" />
                </span>
            </td>
        </tr>
    
    `;
}
function clearResults() {
    //! --> I am sure results will be not null
    tasksUI.innerHTML = "";
}
//# sourceMappingURL=app_v1.js.map