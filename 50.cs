using System;
using System.Collections.Generic;

class Problem50
{
    static void Main(string[] args)
    {
        List<long> primes = Erastosthenes(6000000); // stupid magic number

        int t = int.Parse(Console.ReadLine());
        while (t-- > 0)
        {
            long n = long.Parse(Console.ReadLine());

            long bestSum = 2;
            int bestSteps = 1;
            long bestStart = 2;
            for (int i=0; i<primes.Count; i++)
            {
                if (primes[i] > 131) break; // stupid magic number

                // find biggest sum
                long sum = 0;
                int j = i;
                while (sum + primes[j] < n)
                {
                    sum += primes[j++];
                }

                // decrement until a prime is found
                int steps = j-i;
                while (steps > bestSteps)
                {
                    if (IsPrime(sum, primes))
                    {
                        bestSum = sum;
                        bestSteps = steps;
                        bestStart = primes[i];
                        break;
                    }
                    j -= 1;
                    sum -= primes[j];
                    steps = j-i;
                }
            }
            Console.WriteLine(bestSum + " " + bestSteps);
        }
    }
    static List<long> Erastosthenes(long max)
    {
        var sieve = new bool[max+1];
        var primes = new List<long>();
        for (long i=2; i<=max; i++)
        {
            if (sieve[i] == false) // if prime
            {
                primes.Add(i);
                for (long j=2; j*i <= max; j++)
                {
                    sieve[i*j] = true;
                }
            }
        }
        return primes;
    }
    // checks for prime, given all primes up to sqrt(n) already found
    static bool IsPrime(long n, IEnumerable<long> primes)
    {
        if (n <= 1) return false;

        foreach (long p in primes)
        {
            if (p*p > n) break;
            if (n%p == 0) return false;
        }
        return true;
    }
}
