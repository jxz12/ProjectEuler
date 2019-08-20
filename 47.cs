using System;

class Problem47
{
    static void Main(string[] args)
    {
        string[] split = Console.ReadLine().Split(' ');
        int N = int.Parse(split[0]);
        int K = int.Parse(split[1]);

        int[] factors = NumFactors(N+K-1);
        for (int i=1; i<factors.Length-K+1; i++)
        {
            // two adjacent numbers cannot ever share prime factors!
            // so as long as they have K factors, the factors themselves will be distinct
            bool consecutive = true;
            for (int j=0; j<K; j++)
            {
                if (factors[i+j] != K)
                {
                    consecutive = false;
                    break;
                }
            }
            if (consecutive)
            {
                Console.WriteLine(i);
            }
        }
    }
    static int[] NumFactors(int n)
    {
        // use a sieve of erastothenes to count factors
        var erastothenes = new int[n+1];
        int prime = 2;
        while (prime < n+1)
        {
            if (erastothenes[prime] == 0) // i.e. prime
            {
                // add a factor to all the multiples of prime
                for (int i=2; prime*i < n+1; i++)
                {
                    erastothenes[prime*i] += 1;
                }
            }
            prime += 1;
        }
        return erastothenes;
    }
}
