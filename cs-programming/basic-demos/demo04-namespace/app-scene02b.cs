using Furnitures;  //search for classes in Data
using Data; //also search for classes here

using System;
using Table=Data.Table;
using FTable = Furnitures.Table;
class App
{
    static void Main()
    {
        Chair chair=new Chair();
        Bed bed=new Bed();
        List list = new List();
        Set set = new Set();

        Console.WriteLine(chair);
        Console.WriteLine(bed);
        Console.WriteLine(list);
        Console.WriteLine(set);

        Table table=new Table();
        Console.WriteLine(table) ; //which table?

        FTable table2= new FTable();
        Console.WriteLine(table2);

        Furnitures.Table table3= new Furnitures.Table();
        Console.WriteLine(table3);
    }
}

