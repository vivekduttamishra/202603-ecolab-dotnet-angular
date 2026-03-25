using ConceptArchitect.Utils;

namespace SearchDemo;

public class SearchHelperTests
{

    List<int> numbers = new List<int>{2, 11, 18, 19, 17, 93, 57, 31, 28, 52};


    [Fact]
    public void SearchEventsCanFindEvenNumbers()
    {
        var result = SearchHelper.SearchEvens(numbers);
        foreach(var value in result)
            Assert.True(value%2==0);
    }
    [Fact]
    public void SearcOddEventsCanFindOddNumbers()
    {
        var result = SearchHelper.SearchOdds(numbers);

        foreach(var value in result)
            Assert.True(value%2!=0);

    }
    [Fact]
    public void SearcPrimesCanFindPrimeNumbers()
    {
        var result = SearchHelper.SearchPrimes(numbers);

        foreach(var value in result)
            Assert.True(PrimeUtils.IsPrime(value));
    }
}
