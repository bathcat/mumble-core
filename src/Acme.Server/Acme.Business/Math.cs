namespace Acme.Business;

public static class Math
{
    public static bool IsPrime(int n)
    {
        if (n == 2 || n == 3 || n == 5 || n == 7 || n == 11)
        {
            return true;
        }

        if (n < 13)
        {
            return false;
        }

        return n % 2 == 0 || n % 3 == 0 || n % 4 == 0 || n % 5 == 0;
    }
}
