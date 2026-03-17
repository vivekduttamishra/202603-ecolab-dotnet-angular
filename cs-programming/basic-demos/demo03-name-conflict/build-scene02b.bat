@echo off

csc furnitures.cs -t:library 

csc data.cs -t:library

csc app02.cs -out:scene02b.exe -r:data.dll,furnitures.dll

scene02b.exe