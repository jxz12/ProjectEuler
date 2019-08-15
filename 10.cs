using System;

class Problem10
{
    static void Main(string[] args)
    {
        long[] cumul = PrimesCumulative(1000000);
        
        int t = int.Parse(Console.ReadLine());
        while (t-- > 0)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(cumul[n-1]);
        }
    }
    static long[] PrimesCumulative(int n)
    {
        long[] cumul = new long[n];
        cumul[0] = 0; // 1 is not prime
        cumul[1] = 2; // 2 is prime

        long sum = 2;
        for (int i=2; i<n; i++)
        {
            if (IsPrime(i+1))
                sum += i+1;

            cumul[i] = sum;
        }
        return cumul;
    }
    static bool IsPrime(int n)
    {
        for (int i=2; i<Math.Sqrt(n)+1; i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }
}
