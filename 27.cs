using System;

class Problem27
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        int a = 0, b = 0;
        int best = 0;
        for (int _a=-N; _a<=N; _a++)
        {
            for (int _b=-N; _b<=N; _b++)
            {
                int consecutive = ConsecutivePrimes(_a, _b);
                if (consecutive > best)
                {
                    best = consecutive;
                    a = _a;
                    b = _b;
                }
            }
        }
        Console.WriteLine(a + " " + b);
    }
    static int ConsecutivePrimes(int a, int b)
    {
        int n = 0;
        while (IsPrime(n*n + a*n + b))
        {
            n += 1;
        }
        return n;
    }
    static bool IsPrime(int n)
    {
        if (n <= 1)
        {
            return false;
        }
        int divisor = 2;
        while (divisor*divisor <= n)
        {
            if (n % divisor == 0)
            {
                return false;
            }
            divisor += 1;
        }
        return true;
    }
}
