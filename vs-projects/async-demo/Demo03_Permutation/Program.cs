using ConceptArchitect.Utils;

class Program
{

    static int Factorial(int n)
    {
        int fn = 1;
        for(int i=1;i<=n;i++)
        {
            fn*=i;
            Thread.Sleep(1000);
        }

        return fn;
    }

    static int Permutation(int n, int r)
    {
        var fn= Factorial(n);
        var fn_r= Factorial(n-r);

        var p= fn/fn_r;

        return p;
    }


    static void Main()
    {
        int n=7;
        int r=2;
        System.Console.WriteLine("Please wait...");
        var result = Performance.TimeTaken(()=>Permutation(n,r));
        System.Console.WriteLine($"{n}P{r}={result.Result}\nTotal Time taken:{result.TimeTaken}ms");
    }
}
