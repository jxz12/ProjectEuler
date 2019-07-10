using System;

class Problem11
{
    static void Main(string[] args)
    {
        int[,] grid = new int[20,20];
        for(int grid_i = 0; grid_i < 20; grid_i++)
        {
            string[] grid_row = Console.ReadLine().Split(' ');
            for (int grid_j = 0; grid_j < 20; grid_j++)
            {
                grid[grid_i, grid_j] = int.Parse(grid_row[grid_j]);
            }
        }

        int ans = 0;
        // for every window
        for (int i=0; i<=16; i++)
        {
            for (int j=0; j<=16; j++)
            {
                // do all horizontal, vertical, diagonal
                int diag1 = 1;
                int diag2 = 1;
                for (int k=0; k<4; k++)
                {
                    diag1 *= grid[i+k, j+k];
                    diag2 *= grid[i+k, j+3-k];
                    int horz = 1;
                    int vert = 1;
                    for (int l=0; l<4; l++)
                    {
                        horz *= grid[i+k, j+l];
                        vert *= grid[i+l, j+k];
                    }
                    ans = Math.Max(ans, Math.Max(horz, vert));
                }
                ans = Math.Max(ans, Math.Max(diag1, diag2));
            }
        }
        Console.WriteLine(ans);
    }
}
