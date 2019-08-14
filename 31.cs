using System;

class Problem31
{
    static void Main(string[] args)
    {
        memo = new long[100001];
        memo[0] = 1;

        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Change(n, int.MaxValue));
        }
        // Console.WriteLine(Change(5));
    }
    static long[] memo; // for dynamic programming
    static int[] pennies = new int[]{ 1,2,5,10,20,50,100,200 };

    static long Change(int total, int lastUsed)
    {
        if (memo[total] != 0)
        {
            return memo[total];
        }
        else
        {
            long ways = 0;
            foreach (int penny in pennies)
            {
                if (total >= penny && penny <= lastUsed)
                {
                    ways += Change(total - penny, penny);
                }
            }
            memo[total] = ways;
            return ways;
        }
    } 
}
