namespace TestBankingV1;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        System.Console.WriteLine(   "I am Test 1");
    }

    public void Test2()
    {
        System.Console.WriteLine("I am test 2");
    }

    [Fact]
    public void NotATest()
    {
        System.Console.WriteLine("I am not a test");
    }
}
