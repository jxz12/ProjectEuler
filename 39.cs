using System;
using System.Collections.Generic;

class Problem39
{
    static void Main(string[] args)
    {
        var pCount = CountPs(5000000);

        // calculate max p for each max n
        int max = pCount[0];
        int argmax = 0;
        pCount[0] = 0;
        for (int i=1; i<pCount.Length; i++)
        {
            if (pCount[i] > max)
            {
                max = pCount[i];
                argmax = i;
            }
            pCount[i] = argmax;
        }

        int t = int.Parse(Console.ReadLine());
        while (t-- > 0)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(pCount[n]);
        }
    }
    static int[] CountPs(int pMax)
    {
        var pCount = new int[pMax+1];

        for (int k=1; k<pMax; k++)
        {
            // only need to do the (2,1) tree as odd-odd pairs are ignored
            CoprimeTernary(2, 1, k, pCount);
        }
        return pCount;
    }
    // as in wikipedia article for ternary numbers
    static void CoprimeTernary(int m, int n, int k, int[] pCount)
    {
        // Euclid's formula generalised
        //int p = k*(m*m+n*n) + k*(2*m*n) + k*(m*m-n*n);
        int p = 2*k*(m*m + m*n);
        if (p >= pCount.Length)
        {
            return;
        }
        // Console.WriteLine(k*(m*m+n*n) +" "+ k*(2*m*n) +" "+ k*(m*m-n*n) +" "+ p);
        pCount[p] += 1;
        CoprimeTernary(2*m-n, m, k, pCount);
        CoprimeTernary(2*m+n, m, k, pCount);
        CoprimeTernary(m+2*n, n, k, pCount);
    }
}
