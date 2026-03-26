using ConceptArchitect.Utils;

class Program
{

    static Task<int> Factorial(int n)
    {

        return Task.Factory.StartNew(() =>
        {

            int fn = 1;
            for (int i = 1; i <= n; i++)
            {
                fn *= i;
                Thread.Sleep(1000);
            }

            return fn;
        });

    }


    static Task<int> PermutationAsync(int n, int r)
    {
        var taskFn = Factorial(n);
        var taskFn_r = Factorial(n - r);

        return Task
          .WhenAll(taskFn, taskFn_r) //when both these tasks complete
          //run this task  and return the result
          .ContinueWith(combinedTask =>
          {
              return taskFn.Result / taskFn_r.Result;
          });
    }

     static Task PrintPermutation(int n, int r)
    {
        System.Console.WriteLine($"Calculating {n}P{r}...");
        return  PermutationAsync(n, r)
                    .ContinueWith(t =>
                    {
                        
                        System.Console.WriteLine($"{n}P{r}={t.Result}");
                    });
    }

    static int PermutationAsync_bad(int n, int r)
    {
        var taskFn = Factorial(n);
        var taskFn_r = Factorial(n - r);

        //blocks
        Task.WaitAll(taskFn, taskFn_r);
        //result is ready
        return taskFn.Result / taskFn_r.Result;
    }

    static void PrintPermutation_bad(int n, int r)
    {
        System.Console.WriteLine($"Calculating {n}P{r}...");
        var result = PermutationAsync(n, r);
        System.Console.WriteLine($"{n}P{r}={result}");
    }

    static void Main()
    {
        var t1= PrintPermutation(7, 2);  //will take 7 seconds
        var t2= PrintPermutation(5, 3);  //will take 5 seconds

        Task.WaitAll(t1,t2);
    }
}
