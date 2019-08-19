using System;

class Problem44
{
    static void Main(string[] args)
    {
        string[] split = Console.ReadLine().Split(' ');
        int N = int.Parse(split[0]);
        int K = int.Parse(split[1]);

        for (long i=K+1; i<=N; i++)
        {
            long p_i = (3*i*i-i) / 2;
            long j = i-K;
            long p_j = (3*j*j-j) / 2;

            long sum = p_i + p_j;
            long diff = p_i - p_j;
            if (IsPentagonal(sum) || IsPentagonal(diff))
            {
                Console.WriteLine(p_i);
            }
        }
    }
    // checks if the quadratic equation results in a whole number
    static bool IsPentagonal(long p)
    {
        double n = (1 + Math.Sqrt(1 + 24*p)) / 6;
        return n == Math.Floor(n);
    }
}
