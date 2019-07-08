using System;

class Solution
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++)
        {
            long n = int.Parse(Console.ReadLine());

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
