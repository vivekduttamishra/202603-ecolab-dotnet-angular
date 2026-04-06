

public class Math
{
    public static Task<int> Factorial(int n)
    {
        return Task.Factory.StartNew(() =>
        {
           if(n<0)
             throw new ArgumentOutOfRangeException("Must not be negative");
           int fn = 1;
           while(n>0)
            {
                fn*=n--;
            }

            return fn;
        });

    }

    static async Task PrintFactorial(int n)
    {
        try
        {
            var result = await Factorial(n);
            Console.WriteLine($"Factorial of {n} is {result}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void Main()
    {
       PrintFactorial(7);
       PrintFactorial(3);
    }

    
}