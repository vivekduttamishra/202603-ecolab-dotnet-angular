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

    static int PermutationAsync(int n, int r)
    {
        var tn = Task.Factory.StartNew(()=>Factorial(n));
        var tn_r= Task.Factory.StartNew(()=>Factorial(n-r));

        var fn = tn.Result;
        var fn_r = tn_r.Result;

        var p = fn/fn_r;
        return p;
    }


    static void Main()
    {
        int n=7;
        int r=2;
       
        var response1= Performance.TimeTaken( ()=> Permutation(n,r), $"Permuation({n},{r})");
        System.Console.WriteLine($"Permutation: {response1.Result}\tTimeTaken: {response1.TimeTaken}ms");
        var response2= Performance.TimeTaken(()=> PermutationAsync(n,r), $"PermuationAsync({n},{r})");
        System.Console.WriteLine($"Permutation: {response2.Result}\tTimeTaken: {response2.TimeTaken}ms");
    }
}
