using System;
using System.Collections.Generic;

class Problem29
{
    static void Main(string[] args)
    {
        long N = long.Parse(Console.ReadLine());

        // used to track which exponents are repeats
        var repeats = new Dictionary<long, HashSet<long>>();

        for (long i=2; i<=N; i++)
        {
            long j_exp = 1; // exponent of i to get to j
            long j = i;
            while (j <= N)
            {
                // j and k loop through all pairs of exponents of i
                long k_exp = j_exp + 1;
                long k = j*i;
                while (k <= N)
                {
                    // j_ and k_expexp follow a formula for overlaps
                    long j_expexp = k_exp;
                    long k_expexp = j_exp;
                    while (j_expexp <= N)
                    {
                        if (!repeats.ContainsKey(k))
                            repeats[k] = new HashSet<long>();
                        if (k_expexp > 1)
                            repeats[k].Add(k_expexp);

                        j_expexp += k_exp;
                        k_expexp += j_exp;
                    }
                    k_exp += 1;
                    k *= i;
                }
                j_exp += 1;
                j *= i;
            }
        }
        long totalRepeats = 0;
        foreach (var _repeats in repeats.Values)
        {
            totalRepeats += _repeats.Count;
        }
        Console.WriteLine((N-1)*(N-1) - totalRepeats);
    }
}
