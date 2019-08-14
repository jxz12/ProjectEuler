using System;

class Problem34
{
    static int[] facts = new int[] { 1,1,2,6,24,120,720,5040,40320,362880 };
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int ans = 0;
        for (int i=10; i<N; i++)
        {
            if (SumFacts(i)%i == 0)
            {
                ans += i;
            }
        }
        Console.WriteLine(ans);
    }
    static int SumFacts(int num)
    {
        int total = 0;
        foreach (char c in num.ToString())
        {
            total += facts[c-'0'];
        }
        return total;
    }
}
