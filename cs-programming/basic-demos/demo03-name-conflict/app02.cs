class App
{
    static void Main()
    {
        Chair chair=new Chair();
        Bed bed=new Bed();
        List list = new List();
        Set set = new Set();

        System.Console.WriteLine(chair);
        System.Console.WriteLine(bed);
        System.Console.WriteLine(list);
        System.Console.WriteLine(set);

        Table table=new Table();
        System.Console.WriteLine(table) ; //which table?

    }
}

