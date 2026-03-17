class Math
{
    public static int Factorial(int x)
    {
        int fx=1;
        
        while(x>1)
            fx*=x--;

        return fx;
    }
}

