using System;

class Solution
{
    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++)
        {
            long n = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine(LargestFactor(n));
        }
    }

    static long LargestFactor(long n)
    {
        long factor = SmallestFactor(n);
        while (factor != n)
        {
            n /= factor;
            factor = SmallestFactor(n);
        }
        return n;
    }

    static long SmallestFactor(long n)
    {
        for (int i=2; i<Math.Sqrt(n)+1; i++)
        {
            if (n%i == 0)
            {
                return i;
            }
        }
        return n;
    }
}
