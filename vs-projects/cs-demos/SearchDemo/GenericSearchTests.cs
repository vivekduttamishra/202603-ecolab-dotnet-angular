using ConceptArchitect.Utils;

namespace SearchDemo;

public class GenericSearchTests
{

    List<int> numbers = new List<int> { 2, 11, 18, 19, 17, 93, 57, 31, 28, 52 };
    List<string> words = new List<string> { "Alpha", "Gamma", "Hector", "Orange", "Red", "Pink", "Purple", "Brown", "Gem", "Alt" };


    class EvenMatcher : IMatcher<int>
    {
        public bool IsMatch(int number)
        {
            return number % 2 == 0;
        }
    }


    [Fact]
    public void SearchEventsCanFindEvenNumbers()
    {
        var evens = SearchHelper.Search(numbers, new EvenMatcher());
        foreach (var value in evens)
            Assert.True(value % 2 == 0);
    }


    class InRange : IMatcher<int>
    {
        int min;
        int max;
        public InRange(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
        public bool IsMatch(int value)
        {
            return value >= min && value < max;
        }
    }


    [Fact]
    public void SearchCanSearchNumbersInRange()
    {
        var result = SearchHelper.Search(numbers, new InRange(50, 60));

        Assert.Equal(2, result.Count);
        Assert.Contains(52, result);
        Assert.Contains(57, result);
    }

    class SmallWords : IMatcher<string>
    {
        public bool IsMatch(string value)
        {
            return value.Length < 5;
        }
    }

    [Fact]
    public void SearchCanSearchWordsWithLengthLessThan5()
    {
        var result = SearchHelper.Search(words, new SmallWords());
        Assert.Equal(4, result.Count);
        string [] matchingWords = {"Red","Pink","Alt","Gem"};

        foreach(var matchingWord in matchingWords)
            Assert.Contains(matchingWord, result);
    }

}
