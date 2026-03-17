public class Stats
{
    public static int Permutation(int n, int r)
    {
        return Math.Factorial(n)/Math.Factorial(n-r);
    }

    public static int Combination(int n, int r)
    {
        return Permutation(n,r)/Math.Factorial(r);
    }
}
