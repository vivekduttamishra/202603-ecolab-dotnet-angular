class StatsApp
{
    static void Main()
    {
        int n=5;
        int r=3;

        int permutation = Stats.Permutation(n,r);
        //int combination = Stats.Combination(n,r);  

        // show as 5P3=60
        System.Console.WriteLine(n+"P"+r+" = "+permutation);


        // show as 5C3=10
        //C# string interpolation syntax
        System.Console.WriteLine($"{n}C{r} = {Stats.Combination(n,r)}");
        
    }
}
