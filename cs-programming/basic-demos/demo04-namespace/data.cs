namespace Data;

public class List
{
    public void AddItem(int item)
    {
        System.Console.WriteLine($"Adding the item {item}");
    }
}

public class Set
{
    public void AddItem(int item)
    {
        System.Console.WriteLine($"Adding the item {item}");
    }
}
public class Table
{
    public void AddItem(int row, int column, int item)
    {
        System.Console.WriteLine($"Adding the item {item} to ({row},{column})");
    }
}

