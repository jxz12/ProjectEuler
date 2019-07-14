using System;

class Problem24
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            long n = long.Parse(Console.ReadLine()) - 1;

            string ans = "";
            string remaining = "abcdefghijklm";

            long range = Factorial(12);

            // the letter at each position cuts the possible orders
            // by the number of remaining orders
            for (int i=12; i>0; i--)
            {
                int position = (int)(n / range);
                ans += remaining[position];
                remaining = remaining.Remove(position, 1);

                n %= range;
                range /= i;
            }
            ans += remaining;
            Console.WriteLine(ans);
        }
    }
    static long Factorial(int n)
    {
        int ans = 1;
        for (int i=2; i<=n; i++)
        {
            ans *= i;
        }
        return ans;
    }
}
