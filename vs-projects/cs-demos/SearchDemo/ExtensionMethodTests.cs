using ConceptArchitect.Utils;

namespace SearchDemo;

public class ExtensionMethodTests
{

    List<int> numbers = new List<int> { 2, 11, 18, -19, 17, 93, -2, 57, 31,75, 28,25, 52 };
    List<string> words = new List<string> { "Alpha", "Gamma", "Hector", "Orange", "Red", "Pink", "Purple", "Brown", "Gem", "Alt" };

    [Fact]
    public void CanUseIsPrimeWithInt()
    {
        Assert.True( 13.IsPrime());
        Assert.False((-13).IsPrime());
    }

    [Fact]
    public void CanCheckIfANumberIsNegative()
    {
        int a=-5;

        Assert.True(a.IsNegative());
    }

    [Fact]
    public void CanSearchAllPrimeNumbers()
    {
        var result = numbers.Search(n=>n.IsPrime());
        foreach(var value in result)
            Assert.True(value.IsPrime());
    }

}
