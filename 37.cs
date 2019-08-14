using System;

class Problem37
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        bool[] all = Primes(N-1);
        int ans = 0;
        for (int i=11; i<N; i++)
        {
            if (TrunctableLeft(i, x=>all[x]) && TrunctableRight(i, x=>all[x]))
            {
                ans += i;
            }
        }
        Console.WriteLine(ans);
    }

    static bool TrunctableRight(int x, Func<int, bool> Prime)
    {
        while (x > 0)
        {
            if (!Prime(x))
            {
                return false;
            }
            x /= 10;
        }
        return true;
    }
    static bool TrunctableLeft(int x, Func<int, bool> Prime)
    {
        // truncate from left, but check smallest answer first
        int power10 = 10;
        while (power10 < x)
        {
            if (!Prime(x % power10))
            {
                return false;
            }
            power10 *= 10;
        }
        return true;
    }
    static bool[] Primes(int max)
    {
        var all = new bool[max+1];
        for (int n=0; n<=max; n++)
        {
            all[n] = IsPrime(n);
        }
        return all;
    }
    static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        if (n == 2) return true;
        if (n%2 == 0) return false;

        for (int x=3; x*x<=n; x+=2)
        {
            if (n%x == 0) return false;
        }
        return true;
    }
}
