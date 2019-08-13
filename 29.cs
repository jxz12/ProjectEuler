using System;

class Problem29
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        // TODO: change this into a hashset of sorts
        var repeats = new bool[N+1, N+1]; // used to track which exponents are repeats

        for (int i=2; i<=N; i++)
        {
            int j_exp = 1; // exponent of i to get to j
            int j = (int)Math.Pow(i, j_exp);
            while (j <= N)
            {
                int k_exp = j_exp + 1; // further exponents
                int k = (int)Math.Pow(i, k_exp);
                while (k <= N)
                {
                    int j_expexp = k_exp;
                    int k_expexp = j_exp;
                    while (j_expexp <= N)
                    {
                        // Console.WriteLine("j:" + j + " k:" + k + "_j:" + j_expexp + "_k:" + k_expexp);
                        repeats[k, k_expexp] = true;
                        j_expexp += k_exp;
                        k_expexp += j_exp;
                    }
                    k_exp += 1;
                    k = (int)Math.Pow(i, k_exp);
                }
                j_exp += 1;
                j = (int)Math.Pow(i, j_exp);
            }
        }
        int totalRepeats = 0;
        for (int i=2; i<=N; i++)
        {
            for (int i_exp=2; i_exp<=N; i_exp++)
            {
                if (repeats[i, i_exp] == true)
                {
                    // Console.WriteLine(Math.Pow(i, i_exp));
                    totalRepeats += 1;
                }
            }
        }
        // Console.WriteLine(totalRepeats);
        Console.WriteLine((N-1)*(N-1) - totalRepeats);
    }
}
