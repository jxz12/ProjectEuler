using System;

class Problem14
{
    static void Main(string[] args)
    {
        int bound = 5000000;
        int[] allCollatz = AllCollatz(bound);
        int max = 0, argMax = 0;
        for (int i=1; i<=bound; i++)
        {
            if (allCollatz[i] >= max)
            {
                max = allCollatz[i];
                argMax = i;
            }
            allCollatz[i] = argMax;
        }
        
        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(allCollatz[n]);
        }
    }
    static int[] AllCollatz(int n)
    {
        int[] chains = new int[n+1];
        for (int i=1; i<=n; i++)
        {
            long j = i;
            int chain = 0;
            while (j != 1)
            {
                if (j <= n && chains[j] != 0) // memoisation
                {
                    chain += chains[j];
                    j = 1;
                }
                else
                {
                    chain += 1;
                    if (j % 2 == 0)
                        j = j / 2;
                    else
                        j = 3*j + 1;
                }
            }
            chains[i] = chain;
        }
        return chains;
    }
