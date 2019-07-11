using System;

class Problem15
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);

            Console.WriteLine(CountPaths(n, m));
        }
    }
    static int CountPaths(int n, int m)
    {
        int[,] memo = new int[n+1, m+1];
        for (int i=0; i<=n; i++)
        {
            memo[i,0] = 1;
        }
        for (int j=0; j<=m; j++)
        {
            memo[0,j] = 1;
        }
        return CountPathsRec(n, m, memo);
    }
    static int CountPathsRec(int n, int m, int[,] memo)
    {
        if (memo[n,m] == 0)
        {
            memo[n,m] = (CountPathsRec(n-1, m, memo) +
                         CountPathsRec(n, m-1, memo)) % 1000000007; // prevents overflow
        }
        return memo[n,m];
    }
}
