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
    
    public static VoidFunctionResult TimeTaken(this VoidFunction function)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        function();
        stopWatch.Stop();
        Console.WriteLine($"Total Time taken is {stopWatch.ElapsedMilliseconds} ms");
        return new VoidFunctionResult(){ TimeTaken=stopWatch.ElapsedMilliseconds};
    }

}