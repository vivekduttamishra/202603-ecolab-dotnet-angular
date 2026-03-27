

class Stats
{
    public static  async Task<int> Factorial(int n)
    {
        int fn=1;
        while (n > 0)
        {
            fn*=n--;
            //Thread.Sleep(1000); //can't await
            await Task.Delay(1000);
        }
        //await Task.CompletedTask;
        return fn;
    }   

    public static  async Task<int> Permutation(int n, int r)
    {
        var tfn = Factorial(n);
        var tfn_r= Factorial(n-r);

        var fn = await tfn;
        var fn_r = await tfn_r;

        return fn/fn_r;
    }
}