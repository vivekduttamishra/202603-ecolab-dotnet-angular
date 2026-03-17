class App
{
    static void Main()
    {
        Furnitures.Chair chair=new Furnitures.Chair();
        Furnitures.Bed bed=new Furnitures.Bed();
        Data.List list = new Data.List();
        Data.Set set = new Data.Set();

        System.Console.WriteLine(chair);
        System.Console.WriteLine(bed);
        System.Console.WriteLine(list);
        System.Console.WriteLine(set);

        Furnitures.Table table=new Furnitures.Table();
        System.Console.WriteLine(table) ; //which table?
        
        Data.Table table2=new Data.Table();
        System.Console.WriteLine(table2) ; //which table?
    }
}

