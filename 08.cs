using System;

class Problem8
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        while (t-- > 0)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = int.Parse(tokens_n[0]);
            int k = int.Parse(tokens_n[1]);
            string num = Console.ReadLine();

            int best = 0;
            for (int i=k; i<n; i++)
            {
                int product = 1;
                for (int j=i-k; j<i; j++)
                {
                    product *= num[j] - '0';
                }
                best = Math.Max(best, product);
            }
            Console.WriteLine(best);
        }
    }
}
