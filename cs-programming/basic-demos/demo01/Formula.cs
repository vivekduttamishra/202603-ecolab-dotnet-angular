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