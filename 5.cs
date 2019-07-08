using System;

class Problem5
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());

            int numerator = n;
            while (!TestQuotients(n, numerator))
            {
                numerator += n; // only test multiples of the biggest number
            }
            Console.WriteLine(numerator);
        }
    }
    static bool TestQuotients(int n, int numerator)
    {
        for (int i=1; i<=n; i++)
        {
            if (numerator % i != 0)
                return false;
        }
        return true;
    }
}
