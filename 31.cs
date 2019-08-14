using System;

class Problem31
{
    static void Main(string[] args)
    {
        int[] coins = new int[]{ 1,2,5,10,20,50,100,200 };
        var memo = Change(100001, coins);

        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(memo[n]);
        }
    }

    // returns memoisation table
    static int[] Change(int total, int[] coins)
    {
        var memo = new int[total+1];
        memo[0] = 1;
        foreach (int coin in coins)
        {
            // the number of choices when adding this coin
            // is the number of choices without the coin, plus
            //    the number of choices with the reduced total
            for (int i=coin; i<=total; i++)
            {
                memo[i] = (memo[i] + memo[i-coin]) % 1000000007;
            }
        }
        return memo;
    } 
}
