using System.Security.Cryptography;

class App
{
    static void Main()
    {
        var p1 = new {X=2, Y=3};
        var p2 = new {X=0, Y=0};
        var p3=  new {X=0, Y=0, Z=0};
        var p4 = new {Y=4, X=4};

        ShowInfo(p1);
        ShowInfo(p2);
        ShowInfo(p3);
        ShowInfo(p4);

    }

    static void ShowInfo<T>(T value)
    {
        System.Console.WriteLine($"{value.GetType().Name} => {value}");
    }
}
