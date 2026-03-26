using ConceptArchitect.Utils;

class App
{

    static void Job(int id, int time=1000)
    {
        System.Console.WriteLine($"Job#{id} started on Thread {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(time);
        System.Console.WriteLine($"Job#{id} finished on Thread {Thread.CurrentThread.ManagedThreadId}");
    }


    static void Main()
    {
       
       int count=25;

       Performance.TimeTaken(()=> RunTasks(25));
       
       Performance.TimeTaken(()=> RunTasksAsync(25));





    }

    private static void RunTasks(int count)
    {
        var tasks = new List<Task>();

        for (var i = 1; i <= count; i++)
        {
            var id = i;
            //System.Console.WriteLine("Scheduling Task "+id);
            Job(id);
        }       
    }

    private static void RunTasksAsync(int count)
    {
        var tasks = new List<Task>();

        for (var i = 1; i <= count; i++)
        {
            var id = i;
            //System.Console.WriteLine("Scheduling Task "+id);
            var task = new Task(() => Job(id, 1000));
            task.Start();
            tasks.Add(task);

        }


        System.Console.WriteLine("Waiting for tasks to finish");
        Task.WaitAll(tasks);
        System.Console.WriteLine("All tasks finished");
    }
}
