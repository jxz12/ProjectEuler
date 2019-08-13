using System;
using System.Collections.Generic;

class Problem26
{
    static void Main(string[] args)
    {
        var all = ReciprocateAll(10000);

        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(all[n-1]);
        }
    }
    static int[] ReciprocateAll(int N)
    {
        var allCycles = new int[N+1];
        int max = 0, argmax = 0;
        for (int i=1; i<=N; i++)
        {
            int cycle = Reciprocate(i);
            if (cycle > max)
            {
                max = cycle;
                argmax = i;
            }
            allCycles[i] = argmax;
        }
        return allCycles;
    }
    static int Reciprocate(int divisor)
    {
        int remainder = 1; // first division empty

        var dividends = new Dictionary<int, int>();
        int i = 0;
        while (remainder > 0)
        {
            int dividend = remainder * 10;
            i += 1;
            if (dividends.ContainsKey(dividend))
            {
                return i - dividends[dividend];
            }
            else
            {
                dividends[dividend] = i;
                remainder = dividend % divisor;
            }
        }
        return 0;
    }
}
