
jQuery("#clearButton").on('click',()=>{
    $("#results").empty();
})

document
    .getElementById("calculateButton")
    .onclick=()=>{
        let min = document.getElementById("min").value;

        let max = $("#max").val();
 

        console.log(`calculating primes between ${min}-${max} `)
    };