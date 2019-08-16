using System;

class Problem42
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        while (t-- > 0)
        {
            long t_n = long.Parse(Console.ReadLine());
            Console.WriteLine(InverseTriangular(t_n));
        }
    }
    static long InverseTriangular(long triangular)
    {
        // b^2 - 4ac
        long b2_4ac = 1 + 8*triangular;
        double sqrt = Math.Sqrt(b2_4ac);
        if (Math.Floor(sqrt) == sqrt)
        {
            return (-1 + (long)sqrt) / 2;
        }
        else
        {
            return -1;
        }
    }
}
