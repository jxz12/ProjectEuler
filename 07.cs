using System;

class Problem7
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());

        int[] primes = NthPrimes(10000); // hacky, but in the spec
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(primes[n-1]);
        }
    }
    static int[] NthPrimes(int n)
    {
        int[] allPrimes = new int[n];
        allPrimes[0] = 2;

        int nextAttempt = 1;
        int i = 1;
        while (i < n)
        {
            nextAttempt += 2;
            if (IsPrime(nextAttempt))
            {
                allPrimes[i++] = nextAttempt;
            }
        }
        return allPrimes;
    }
    static bool IsPrime(int n)
    {
        for (int i=2; i<=Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}
