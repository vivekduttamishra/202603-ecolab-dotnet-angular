using System;
using ConceptArchitect.Utils;

class App{

	static void Main(){

		int n=5;
		var fn = Factorial.Calculate(n);

		Console.WriteLine($"Factorial of {n} is {fn}");
	}

}