@echo off

dotnet new %1 -n %2 -o %2

dotnet solution add %2