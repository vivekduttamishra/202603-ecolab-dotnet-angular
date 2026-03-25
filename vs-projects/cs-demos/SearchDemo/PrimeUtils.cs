namespace ConceptArchitect.Utils;

public class PrimeUtils
{
    
    public static  bool IsPrime(int value)
    {
        if(value<2)
            return false;

        for(var i=2;i<value;i++)
            if(value%i==0)
                return false;

        return true;
    }

}