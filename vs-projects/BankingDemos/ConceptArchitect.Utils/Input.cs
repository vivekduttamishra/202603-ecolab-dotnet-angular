namespace ConceptArchitect.Utils;

public class Input
{
    public  string GetString(string prompt, string defaultValue="")
    {
        Console.Write(prompt);
        var value = Console.ReadLine();

        if(value.Trim()=="")
            return defaultValue;
        else
            return value;
    }

    public  int GetInt(string prompt, int defaultValue=0)
    {
        var value = GetString(prompt,"0");
        return int.Parse(value); //conver the value to int
    }
    public  double GetDouble(string prompt, double defaultValue=0)
    {
        var value = GetString(prompt,"0");
        return double.Parse(value); //conver the value to int
    }
}

