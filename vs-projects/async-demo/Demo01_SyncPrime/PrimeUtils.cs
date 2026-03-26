namespace ConceptArchitect.Utils;

public static class PrimeUtils
{
    
    public static bool IsPrime(this int number)
    {
        if(number<2) return false;
        for(var i=2;i<number;i++)
            if(number%i==0)
                return false;


        return true;
    }

    public static List<int> FindPrimes(int min,int max)
    {
        var primes = new List<int>();
        for(var i = min; i < max; i++)
        {
            if(IsPrime(i))
                primes.Add(i);
        }

        return primes;
    }

}