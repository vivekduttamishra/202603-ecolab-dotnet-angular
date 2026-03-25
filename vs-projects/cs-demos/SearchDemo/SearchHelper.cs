

namespace ConceptArchitect.Utils;

public class SearchHelper
{
    public static  List<int> SearchEvens(List<int> numbers)
    {
        var result = new List<int>();
        foreach(var number in numbers)
            if(number%2==0)
                result.Add(number);
        return result;
    }

    public static List<int> SearchOdds(List<int> numbers)
    {
        var result = new List<int>();
        foreach(var number in numbers)
            if(number%2!=0)
                result.Add(number);

        return result;
    }

    public static List<int> SearchPrimes(List<int> numbers)
    {
        var result = new List<int>();
        foreach(var number in numbers)
            if(PrimeUtils.IsPrime(number))
                result.Add(number);

        return result;
    }
}