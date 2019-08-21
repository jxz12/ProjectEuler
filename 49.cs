using System;
using System.Collections.Generic;

class Problem49
{
    static void Main(string[] args)
    {
        string[] split = Console.ReadLine().Split(' ');
        int N = int.Parse(split[0]);
        int K = int.Parse(split[1]);

        // find all primes O(n^2)
        // divide them into anagram buckets (sort string) O(n^2log(n))
        // iterate over pairs within buckets and test for jumps O(b^2)

        var primes = Erastosthenes(1000000);

        // do one amount of digits at a time to avoid leading 0 issues
        var buckets = GetBuckets(primes, 1000, 9999);
        UnusualPrimes(buckets, N, K);
        buckets = GetBuckets(primes, 10000, 99999);
        UnusualPrimes(buckets, N, K);
        buckets = GetBuckets(primes, 100000, 999999);
        UnusualPrimes(buckets, N, K);

    }
    static void UnusualPrimes(Dictionary<int, List<int>> buckets, int N, int K)
    {
        var unusuals = new List<string>();
        foreach (var bucket in buckets.Values)
        {
            if (bucket.Count < K) continue;

            // over all pairs of primes, see if there exist
            // further elements in the sequence
            var bucketHash = new HashSet<int>(bucket);
            for (int i=0; i<bucket.Count-K+1; i++)
            {
                int prime1 = bucket[i];
                if (prime1 >= N) continue;

                for (int j=i+1; j<bucket.Count; j++)
                {
                    int prime2 = bucket[j];
                    int jump = prime2 - prime1;

                    // ugly and hard-coded here for the sake of the spec ;)
                    if (K == 3)
                    {
                        if (bucketHash.Contains(prime2+jump))
                        {
                            unusuals.Add(prime1.ToString()
                                + prime2.ToString()
                                + (prime2+jump).ToString());
                        }
                    }
                    else if (bucketHash.Contains(prime2+jump) &&
                             bucketHash.Contains(prime2+jump+jump))
                    {
                        unusuals.Add(prime1.ToString()
                            + prime2.ToString()
                            + (prime2+jump).ToString()
                            + (prime2+jump+jump).ToString());
                    }
                }
            }
        }
        unusuals.Sort();
        foreach (string unusual in unusuals)
        {
            Console.WriteLine(unusual);
        }
    }
    static Dictionary<int, List<int>> GetBuckets(List<int> primes, int min, int max)
    {
        // creates buckets full of anagrams
        var buckets = new Dictionary<int, List<int>>();
        foreach (int prime in primes)
        {
            if (prime < min || prime > max) continue;
            
            int sorted = SortDigits(prime);
            List<int> bucket;
            if (buckets.TryGetValue(sorted, out bucket))
            {
                bucket.Add(prime);
            }
            else
            {
                buckets[sorted] = new List<int>();
                buckets[sorted].Add(prime);
            }
        }
        return buckets;
    }
    static int SortDigits(int input)
    {
        // returns a lexicographically sorted version of the input
        int numDigits = 1;
        int pow = 10;
        while (input/pow > 0)
        {
            numDigits += 1;
            pow *= 10;
        }
        int[] digits = new int[numDigits];
        digits[0] = input % 10;
        for (int i=1; i<numDigits; i++)
        {
            input /= 10;
            digits[i] = input % 10;
        }

        Array.Sort(digits);

        int sorted = digits[0];
        for (int i=1; i<numDigits; i++)
        {
            sorted *= 10;
            sorted += digits[i];
        }
        return sorted;
    }
    // sieve
    static List<int> Erastosthenes(int max)
    {
        var sieve = new bool[max+1];
        for (int i=2; i<=max; i++)
        {
            if (sieve[i] == false) // if prime
            {
                for (int j=2; j*i <= max; j++)
                {
                    sieve[i*j] = true;
                }
            }
        }
        var primes = new List<int>();
        for (int i=2; i<=max; i++)
        {
            if (sieve[i] == false)
            {
                primes.Add(i);
            }
        }
        return primes;
    }
}
