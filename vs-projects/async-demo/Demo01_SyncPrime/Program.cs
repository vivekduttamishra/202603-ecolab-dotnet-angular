
using ConceptArchitect.Utils;
class Program
{
    static void Main()
    {
        Performance.TimeTaken(() => PrintPrimeRange(2,200000));
        
        Performance.TimeTaken(() => PrintPrimeRange(2,200));
       

    }

    static void PrintPrimeRange(int min,int max)
    {
        var primes = PrimeUtils.FindPrimes(min,max);
        System.Console.WriteLine($"Total Primes Found is {primes.Count}");
    }


}
