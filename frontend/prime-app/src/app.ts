

function isPrime(number:number){
    if(number<2)
        return false;

    for(let i=2;i<number;i++)
        if(number%i==0)
            return false;

    return true;
}

function delay(time:number):Promise<void>{
    return new Promise((resolve,reject)=>{
        setTimeout(resolve, time);
    })
}

async function findPrimes(min:number,max:number):Promise<number[]>{

    if(min>=max)
        throw new Error(`Invalid Range ${min}-${max}`);

    let result:number[]=[];

    for(let i=min;i<max;i++){
        if(isPrime(i))
            result.push(i);
        if(i%1000===0){
            //lets wait for 1 second
            //setTimeout(()=>{},1);
            await delay(1);
        }
    }

    return result;

}




const tasksUI= document.getElementById("results");
const minBox:any = document.getElementById("min");
const maxBox:any=document.getElementById("max");

minBox.value=2;
maxBox.value=200000;

type Task={
    id:number,
    min:number,
    max:number,
    primes?: number[],
    error?:string,
    status:"running"|"done"|"error"|"idle"
}

let tasks :Task[]=[];
let taskCount=0;

clearResults();

function addTask(){
    //console.log('Calculation Started')
    let min = Number(minBox.value);
    var max = + maxBox.value; // + converts to number
    let task:Task={
        id:++taskCount,
        min,
        max,        
        status:"running"
    }
    tasks.push(task);

    const row = createRow(task);

    tasksUI!.innerHTML+= row;
    updateRow(task);

    let promise = findPrimes(task.min,task.max);

    promise
        .then(primes=>{

            task.primes=primes;
            task.status="done";
            updateRow(task);
        })
        .catch(error=>{
            task.error=error.message;
            task.status="error";
            updateRow(task);
        })




}

function show(id:string, visible:boolean){
        let e = document.getElementById(id);
        if(visible)
            e!.style.display="inline";
        else
            e!.style.display="none";
}

function updateRow(task:Task){

    let errorId= `${task.id}-error`
    let successId= `${task.id}-success`
    let waitId= `${task.id}-waiting`
    show(errorId,false)
    show(successId,false)
    show(waitId,false)

    switch(task.status){
        case "error":
            show(errorId, true)
            document.getElementById(errorId)!.innerHTML=task.error!
            break;
        case "done":
            show(successId, true)
            document.getElementById(successId)!.innerHTML=task.primes!.length.toString()
            break;
        case "running":
            show(waitId,true);
            break;
    }


}

function createRow(task:Task):string{
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
    
    `
}



function clearResults(){
    //! --> I am sure results will be not null
    tasksUI!.innerHTML="";
}   