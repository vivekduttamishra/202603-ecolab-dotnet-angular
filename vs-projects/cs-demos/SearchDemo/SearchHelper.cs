

namespace ConceptArchitect.Utils;

public interface IIntMatcher
{
    bool IsMatch(int number);
}

public interface IMatcher<T>
{
    bool IsMatch(T value);
}

public delegate bool Matcher<E>(E value);


public static  class SearchHelper
{

    public static List<X> Search<X>(this List<X> values, Matcher<X> matcher)
    {
        var result = new List<X>();
        foreach(var value in values)
        {
            if(matcher(value))
                result.Add(value);
        }

        return result;
    }

    public static List<X> Search<X>(List<X> values, IMatcher<X> matcher)
    {
        var result = new List<X>();
        foreach(var value in values)
        {
            if(matcher.IsMatch(value))
                result.Add(value);
        }

        return result;
    }

     public static  List<int> SearchInt(List<int> numbers, IIntMatcher matcher)
    {
        var result = new List<int>();
        foreach(var number in numbers)
            if(matcher.IsMatch(number))
                result.Add(number);
        return result;
    }
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