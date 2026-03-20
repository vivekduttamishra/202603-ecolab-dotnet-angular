namespace ConceptArchitect.Utils;

public class Factorial
{

	public static int Calculate(int n)
	{
		if(n<2)
			return 1;	

		else
			return n*Calculate(n-1);
	
	}

}