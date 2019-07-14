using System;
using System.Numerics;

class Problem20
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());
            
            BigInteger big = Factorial(n);

            string s = big.ToString();
            int ans = 0;
            foreach (char c in s)
            {
                ans += c - '0';
            }
            Console.WriteLine(ans);
        }
    }
    static BigInteger Factorial(int n)
    {
        BigInteger big = 1;
        for (int i=1; i<=n; i++)
        {
            big *= i;
        }
        return big;
    }
}
