using System;
using System.Collections.Generic;

class Problem29
{
    // I'll have my own HashSet... with blackjack and hookers...
    public class BoolMatrix
    {
        private Dictionary<int, uint[]> matrix;
        private int numCells;
        public BoolMatrix(int size)
        {
            numCells = (int)Math.Ceiling((double)size / 32);
            matrix = new Dictionary<int, uint[]>();
        }
        public void SetTrue(int row, int col)
        {
            row -= 1;
            col -= 1;
            if (!matrix.ContainsKey(row))
            {
                matrix[row] = new uint[numCells];
            }
            matrix[row][col/32] |= (uint)(1 << (col%32));
        }
        public long CountTrues()
        {
            long trues = 0;
            foreach (var row in matrix.Values)
            {
                for (int i=0; i<row.Length; i++)
                {
                    trues += CountBits(row[i]);
                }
            }
            return trues;
        }
        private int CountBits(uint n)
        {
            int count = 0;
            while (n > 0)
            {
                n &= n-1;
                count += 1;
            }
            return count;
        }
    }
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        var matrix = new BoolMatrix(N);
        int i = 2;
        while (i*i <= N)
        {
            int j_exp = 1; // exponent of i to get to j
            long j = i;
            while (j <= N)
            {
                // j and k loop through all pairs of exponents of i
                int k_exp = j_exp + 1;
                long k = j*i;
                while (k <= N)
                {
                    // j_ and k_expexp follow a formula for overlaps
                    int j_expexp = k_exp;
                    int k_expexp = j_exp;
                    while (j_expexp <= N)
                    {
                        if (k_expexp > 1)
                        {
                            matrix.SetTrue((int)k, k_expexp);
                        }
                        j_expexp += k_exp;
                        k_expexp += j_exp;
                    }
                    k_exp += 1;
                    k *= i;
                }
                j_exp += 1;
                j *= i;
            }
            i += 1;
        }
        Console.WriteLine((long)(N-1)*(long)(N-1) - matrix.CountTrues());
    }
}
