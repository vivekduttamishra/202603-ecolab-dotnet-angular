using System.Diagnostics;

namespace ConceptArchitect.Utils;


public delegate T Function<T>();
public delegate void VoidFunction();

public class VoidFunctionResult
{
    public long TimeTaken { get; set; }     
}

public class FunctionResult<T>
{
    public long TimeTaken { get; set; }
    public T Result{ get; set; }
}



public static class Performance
{
    
    public static VoidFunctionResult TimeTaken(this VoidFunction function,string message="")
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        System.Console.WriteLine($"Starting {message}");
        function();
        stopWatch.Stop();
        Console.WriteLine($"Total Time taken by {message} is {stopWatch.ElapsedMilliseconds} ms");
        
        return new VoidFunctionResult(){ TimeTaken=stopWatch.ElapsedMilliseconds};
    }

    public static FunctionResult<T>  TimeTaken<T>(this Function<T> function, string message="")
    {
        var result = new FunctionResult<T>();

        Stopwatch watch =new Stopwatch();
        //System.Console.WriteLine($"Starting {message}");
        watch.Start();
        result.Result= function();
        watch.Stop();
        result.TimeTaken=watch.ElapsedMilliseconds;
        return result;
        
    }

}