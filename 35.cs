using System;

class Problem35
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        bool[] all = Primes(1000000);
        int ans = 0;
        for (int i=2; i<=N; i++)
        {
            if (Circular(i, a=>all[a]))
            {
                ans += i;
            }
        }
        Console.WriteLine(ans);
    }

    static bool Circular(int x, Func<int, bool> Prime)
    {
        if (!Prime(x)) return false;

        string s = x.ToString();
        int mag = (int)Math.Pow(10, s.Length-1);
        for (int i=s.Length-1; i>=1; i--)
        {
            // rotate
            x = (x/10) + mag*(s[i]-'0');
            if (!Prime(x))
            {
                return false;
            }
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
