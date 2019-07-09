using System;

class Solution
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(PythagoreanTriplet(n));
        }
    }
    static int PythagoreanTriplet(int n)
    {
        int ans = -1;
        for (int a=1; a<=n-3; a++)
        {
            int b_top = 2*a*n - n*n;
            int b_bot = 2*a - 2*n;

            if (b_top < 0 && -b_top % -b_bot == 0)
            {
                int b = b_top / b_bot;
                int c = n - a - b;
                ans = Math.Max(ans, a*b*c);
            }
        }
        return ans;
    }
}

