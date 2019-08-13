using System;
using System.Collections.Generic;

class Problem29
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        // used to track which exponents are repeats
        var repeats = new Dictionary<int, HashSet<int>>();
        long numRepeats = 0;

        for (int i=2; i<=N; i++)
        {
            if (repeats.ContainsKey(i))
            {
                numRepeats += repeats[i].Count;
                repeats.Remove(i);
            }

            int j_exp = 1; // exponent of i to get to j
            long j = i;
            while (j <= N)
            {
                // j and k loop through all pairs of exponents of i
                int k_exp = j_exp + 1;
                long k = j*i;
                while (k <= N)
                {
                    // j_ and k_expexp follow a formula for overlaps
                    int j_expexp = k_exp;
                    int k_expexp = j_exp;
                    while (j_expexp <= N)
                    {
                        if (!repeats.ContainsKey((int)k))
                            repeats[(int)k] = new HashSet<int>();
                        if (k_expexp > 1)
                            repeats[(int)k].Add(k_expexp);

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
        Console.WriteLine((long)(N-1)*(long)(N-1) - numRepeats);
    }
}
