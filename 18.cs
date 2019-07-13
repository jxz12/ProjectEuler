using System;
using System.Numerics;

class Problem18
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] triangle = new int[n][];
            int[][] memo = new int[n][];
            for (int a1 = 0; a1 < n; a1++)
            {
                triangle[a1] = new int[a1+1];
                memo[a1] = new int[a1+1];
                string[] row = Console.ReadLine().Split(' ');
                for (int a2 = 0; a2 < a1+1; a2++)
                {
                    triangle[a1][a2] = int.Parse(row[a2]);
                    // memo[a1][a2] = 0;
                }
            }
            Console.WriteLine(MaxPathSum(triangle, 0, 0, memo));
        }
    }
    static int MaxPathSum(int[][] triangle, int row, int col, int[][] memo)
    {
        if (row == triangle.Length-1) // || col >= triangle[row].Length)
        {
            memo[row][col] = triangle[row][col];
        }
        else if (memo[row][col] == 0) // if path has not been seen yet
        {
            int left = MaxPathSum(triangle, row+1, col, memo);
            int right = MaxPathSum(triangle, row+1, col+1, memo);
            memo[row][col] = Math.Max(left, right) + triangle[row][col];
        }
        return memo[row][col];
    }
}
