using System.ComponentModel.DataAnnotations;
using ConceptArchitect.Utils;

class Program
{
    static void Main()
    {
        //TestSyncVsAsync();

        var t1= FindAndPrintPrimesAsync(2,500000);
        var t2=FindAndPrintPrimesAsync(2,200);
        var t4=FindAndPrintPrimesAsync(2,200000);
        var t3=FindAndPrintPrimesAsync(2,50000);

        System.Console.WriteLine("Waiting for all tasks to complete");
        Task.WaitAll(t1,t2,t3,t4);
        System.Console.WriteLine("Program ends...");

    }


      static Task FindAndPrintPrimesAsync(int min, int max)
    {
        System.Console.WriteLine($"Finding Primes between {min}-{max}");
        var computeTask = Task.Factory.StartNew(()=>PrimeUtils.FindPrimes(min,max));

        //I don't know when task will complete.
        //And I don't want to wait for it yet.
        //we will tell what to do when task completes.
        //this task will start and finish in future
        //so it returns another task
       var printTask= computeTask.ContinueWith(t =>
        {
            var primes = t.Result; //NOT BLOCKING. TASK IS ALREADY COMPLETED.
            Console.WriteLine($"Total Primes between {min}-{max} is {primes.Count}");
           
        });

        return printTask;

        
    }


    static void FindAndPrintPrimesAsync_bad(int min, int max)
    {
        System.Console.WriteLine($"Finding Primes between {min}-{max}");
        var task = Task.Factory.StartNew(()=>PrimeUtils.FindPrimes(min,max));
        //we can wait for the task to be over
        var primes = task.Result; //it waits for the result.
        //wait =>syncrhonous

        System.Console.WriteLine($"Total Priems Found between {min}-{max} : {primes.Count}");
    }







    private static void TestSyncVsAsync()
    {
        Performance.TimeTaken(() => FindAndPrintPrimesSync(2, 500000));
        Performance.TimeTaken(() => FindAndPrintPrimesAsync(2, 500000));
    }

   

    static void FindAndPrintPrimesSync(int min, int max)
    {
        System.Console.WriteLine($"Finding Primes between {min}-{max}");
        var primes = PrimeUtils.FindPrimes(min,max);
        System.Console.WriteLine($"Total Primes Found between {min}-{max}: {primes.Count}");
    }


}