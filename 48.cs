using System;

class Problem48
{
    static void Main(string[] args)
    {
        long N = long.Parse(Console.ReadLine());

        long ans = 1;
        for (long i=2; i<=N; i++)
        {
            long factor = Exponentiate(i, i);
            ans = (ans + factor) % 10000000000;
        }
        Console.WriteLine(ans);
    }
    // exponentiation by squaring
    static long Exponentiate(long n, long exp)
    {
        long ans = 1;
        for (int i=20; i>=0; i--)
        {
            ans = Multiply(ans, ans);
            if (((exp>>i) & 1) == 1)
            {
                ans = Multiply(ans, n);
            }
        }
        return ans;
    }
    static long Multiply(long a, long b)
    {
        // convert to base 100000 and throw away excess
        long a0 = a%100000;
        long a1 = a/100000;
        long b0 = b%100000;
        long b1 = b/100000;

        long ans0 = a0 * b0;
        long remainder = ans0 / 100000;
        ans0 = ans0 % 100000;

        long ans1 = a0*b1 + a1*b0 + remainder;
        ans1 = ans1 % 100000;

        return ans0 + 100000 * ans1;
    }
}
