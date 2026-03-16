
class FactorialApp03
{

	static void Main()
	{
		int n=5;

		Formula formula = new Formula();

		int fn = formula.Factorial(n);

		System.Console.WriteLine( "Factorial of " + n + " is " + fn);
		
	}
}

