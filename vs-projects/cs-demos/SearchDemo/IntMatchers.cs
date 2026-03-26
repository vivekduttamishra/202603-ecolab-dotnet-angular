

public static class IntMatchers
{
    
    public static bool IsEven(this int value) { return value%2==0;}
    public static bool IsOdd(this int value) { return value%2!=0;}
    public static bool IsDivisibleBy3(this int value) { return value%3==0;}
    public static bool IsNegative(this int value) { return value<0;}
    public static bool IsPositive(this int value) { return value<0;}


}