

setTimeout(()=>{
    console.log("Hello World after 5 seconds!!!");
    
}, 5000)

let count = 5

let iid= setInterval(()=>{
    console.log(`Countdown ${count}...`)
    count--;
    if(count===1){

        clearInterval(iid)
        clearInterval(iid2)
    }
},1000)

let iid2= setInterval(()=>{
    
    console.log("***")
    
        
},100)

//this code runs immediately
console.log("Please wait somehting BIG will happen in 5 seconds!")