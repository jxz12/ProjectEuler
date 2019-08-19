using System;

class Problem45
{
    static void Main(string[] args)
    {
        string[] split = Console.ReadLine().Split(' ');
        long N = long.Parse(split[0]);
        int a = int.Parse(split[1]);
        int b = int.Parse(split[2]);

        Func<long, bool> CheckLower = a==3? (Func<long,bool>)IsTriangular : IsPentagonal;
        Func<long, long> GetUpper = a==3? (Func<long,long>)GetPentagonal : GetHexagonal;

        long i = 1;
        long n = GetUpper(i);
        while (n < N)
        {
            if (CheckLower(n))
            {
                Console.WriteLine(n);
            }
            n = GetUpper(++i);
        }
    }
    static long GetPentagonal(long n)
    {
        return (3*n*n - n) / 2;
    }
    static long GetHexagonal(long n)
    {
        return 2*n*n - n;
    }
    static bool IsTriangular(long t)
    {
        double n = (-1 + Math.Sqrt(1 + 8*t)) / 2;
        return n == Math.Floor(n);
    }
    static bool IsPentagonal(long p)
    {
        double n = (1 + Math.Sqrt(1 + 24*p)) / 6;
        return n == Math.Floor(n);
    }
}
