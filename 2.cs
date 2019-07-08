using System;

class Problem2
{
    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            long n = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine(EvenFibonacciNaive(n));
        }
    }
    static long EvenFibonacciNaive(long n)
    {
        long curr = 1, prev = 0;
        long sum = 0;
        while (curr<n)
        {
            if (curr % 2 == 0)
            {
                sum += curr;
            }
            long next = curr + prev;
            prev = curr;
            curr = next;
        }
        return sum;
    }
}
