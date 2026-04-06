document.write("Hello World!!!")
document.write("Hello World, Again!!!")


var info = document.getElementById("dynamic-info");


//now we can modify the style of the element
info.style.color="maroon";
info.style.border="1px solid brown";
info.style.padding="10px";

info.innerHTML="New information added";

console.log('info added');
document.write("info added");

