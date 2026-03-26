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
        for(var i=1;i<=25;i++)
        {
            Job(i,1000);
        }
    }
}
