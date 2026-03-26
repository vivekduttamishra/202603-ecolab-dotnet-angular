using ConceptArchitect.Utils;

namespace SearchDemo;

public class DelegateSearchTests
{

    List<int> numbers = new List<int> { 2, 11, 18, -19, 17, 93, -2, 57, 31,75, 28,25, 52 };
    List<string> words = new List<string> { "Alpha", "Gamma", "Hector", "Orange", "Red", "Pink", "Purple", "Brown", "Gem", "Alt" };


    // class EvenMatcher : IMatcher<int>
    // {
    //     public bool IsMatch(int number)
    //     {
    //         return number % 2 == 0;
    //     }
    // }

    bool IsEven(int value)
    {
        return value%2==0;
    }


    [Fact]
    public void SearchEventsCanFindEvenNumbers()
    {
        var evens = SearchHelper.Search(numbers, IsEven);
        foreach (var value in evens)
            Assert.True(value % 2 == 0);
    }

    [Fact]
    public void SearchCanSearchPrimes()
    {
        var primes = SearchHelper.Search(numbers, PrimeUtils.IsPrime);
        foreach(var value in primes)
            Assert.True(PrimeUtils.IsPrime(value));
    }

    [Fact]
    public void SearchCanUseExistingMatchersToFindNegativeNumbers()
    {
        var negatives = SearchHelper.Search(numbers, IntMatchers.IsNegative);

        Assert.Equal(2, negatives.Count);
    }

    bool DivisibleBy5(int value)
    {
        return value%5==0;
    }

    [Fact]
    public void SearchCanSearchAllNumbersDivisibleBy5()
    {
        Matcher<int> divisibleBy5 = delegate(int value)
        {
            return value%5==0;
        };

        var result = SearchHelper.Search(numbers, divisibleBy5);

        Assert.Equal(2, result.Count);
        
    }

    [Fact]
    public void SearchCanSearchAllNumbersDivisibleBy3()
    {
        Matcher<int> divisibleBy3 = value => value%3==0     ;

        var result = SearchHelper.Search(numbers, divisibleBy3);

        Assert.Equal(4, result.Count);
        
    }

    [Fact]
    public void SearchCanFindAllStringStartingWithA()
    {
        var result = SearchHelper.Search(words, delegate(string word)
        {
            return word[0]=='A';
        });

        Assert.Equal(2, result.Count);
        Assert.Contains("Alpha",result);
        Assert.Contains("Alt",result);
    }


    // class InRange : IMatcher<int>
    // {
    //     int min;
    //     int max;
    //     public InRange(int min, int max)
    //     {
    //         this.min = min;
    //         this.max = max;
    //     }
    //     public bool IsMatch(int value)
    //     {
    //         return value >= min && value < max;
    //     }
    // }


    [Fact(
        Skip ="Not Yet Implemented"
    )]
    public void SearchCanSearchNumbersInRange()
    {
        var result = SearchHelper.Search(numbers, value=> value>=50 && value<60 );

        Assert.Equal(2, result.Count);
        Assert.Contains(52, result);
        Assert.Contains(57, result);
    }

    // class SmallWords : IMatcher<string>
    // {
    //     public bool IsMatch(string value)
    //     {
    //         return value.Length < 5;
    //     }
    // }

    bool SmallWord(string value)
    {
        return value.Length < 5;
    }

    [Fact]
    public void SearchCanSearchWordsWithLengthLessThan5()
    {
        var result = SearchHelper.Search(words, SmallWord);
        Assert.Equal(4, result.Count);
        string [] matchingWords = {"Red","Pink","Alt","Gem"};

        foreach(var matchingWord in matchingWords)
            Assert.Contains(matchingWord, result);
    }

}
