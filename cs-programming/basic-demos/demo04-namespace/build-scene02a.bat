@echo off

csc furnitures.cs -t:library 

csc data.cs -t:library

csc app.cs -out:scene02a.exe -r:data.dll,furnitures.dll

scene02a.exe
