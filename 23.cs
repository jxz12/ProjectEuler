using System;

class Problem23
{
    static void Main(string[] args)
    {
        bool[] a = AllAbundants(100000);

        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());
            string result = "NO";
            for (int i=1; i<=n; i++)
            {
                if (a[i] == true && a[n-i] == true)
                {
                    result = "YES";
                    break;
                }
            }
            Console.WriteLine(result);
        }
    }
    static bool[] AllAbundants(int n)
    {
        bool[] all = new bool[n+1];
        for (int i=1; i<=n; i++)
        {
            all[i] = SumDivisors(i) > i? true : false;
        }
        return all;
    }
    static int SumDivisors(int n)
    {
        if (n == 1)
        {
            return 1;
        }
        int ans = 1;
        int sqrt = (int)Math.Sqrt(n);
        for (int i=2; i<=sqrt; i++)
        {
            if (n % i == 0)
            {
                ans += i + n/i;
            }
        }
        if (Math.Sqrt(n) == sqrt)
        {
            ans -= sqrt;
        }
        return ans;
    }
}
