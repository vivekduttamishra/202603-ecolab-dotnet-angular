

using System.Threading.Tasks;

class Program
{
    static async Task PrintPermutationResult(int n,int r)
    {
        System.Console.WriteLine($"calculating {n}P{r}...");
        var p = await Stats.Permutation(n,r);
        System.Console.WriteLine($"calcuating {n}P{r}={p}");
    }
    static async Task Main()
    {
       var t1= PrintPermutationResult(7,2);
       var t2= PrintPermutationResult(5,3);

       Task.WaitAll(t1,t2);
        System.Console.WriteLine("End of program");
    }
}