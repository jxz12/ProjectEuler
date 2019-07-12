using System;
using System.Numerics;

class Problem16
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());
            
            BigInteger big = 1;
            big = big << n;

            string s = big.ToString();
            int ans = 0;
            foreach (char c in s)
            {
                ans += c - '0';
            }
            Console.WriteLine(ans);
        }
    }
}
