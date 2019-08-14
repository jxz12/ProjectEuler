using System;
using System.Collections.Generic;

class Problem33
{
    static void Main(string[] args)
    {
        // always one digit so this is okay
        string both = Console.ReadLine();
        int N = both[0] - '0';
        int K = both[2] - '0';

        int min = (int)Math.Pow(10, N);
        int max = (int)Math.Pow(10, N+1) - 1;
        int numSum = 0;
        int denSum = 0;
        for (int num=min; num<=max-1; num++)
        {
            for (int den=num+1; den<max; den++)
            {
                if (CanCancel(num, den, K))
                {
                    numSum += num;
                    denSum += den;
                }
            }
        }
        Console.WriteLine(numSum + " " + denSum);
    }
    // if the top and bottom share more than K digits (not zeros)
    static bool CanCancel(int num, int den, int K)
    {
        var numHash = new HashSet<char>(num.ToString());
        int shared = 0;
        foreach (char c in den.ToString())
        {
            if (c != '0' && numHash.Contains(c))
            {
                shared += 1;
                if (shared == K)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
