using System;

class Problem21
{
    static void Main(string[] args)
    {
        int[] d = AllDivisorSums(100000);
        int[] am = AllAmicable(d);

        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(am[n-1]);
        }
    }
    static int[] AllAmicable(int[] d)
    {
        int n = d.Length - 1;
        int[] all = new int[n+1];
        int sum = 0;
        for (int i=220; i<=n; i++) // first amicable num is 220
        {
            int a = d[i];
            int b = a<=n? d[a] : SumDivisors(a);
            if (b == i && a != b)
            {
                sum += i;
            }
            all[i] = sum;
        }
        return all;
    }
    static int[] AllDivisorSums(int n)
    {
        int[] all = new int[n+1];
        for (int i=1; i<=n; i++)
        {
            all[i] = SumDivisors(i);
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
