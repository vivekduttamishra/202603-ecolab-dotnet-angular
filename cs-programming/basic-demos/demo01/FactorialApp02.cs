
class FactorialApp02
{

	static void Main()
	{
		int n=5;

		Formula formula = new Formula();

		int fn = formula.Factorial(n);

		System.Console.WriteLine( "Factorial of " + n + " is " + fn);
		
	}
}

class Formula
{

	public int Factorial(int x)
	{
		int fx = 1;
		
		while(x>1)
		{
			fx=fx*x;
			x--; 
		}
		return fx;		
	}

}