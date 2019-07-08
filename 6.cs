using System;

class Problem6
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());

            long sumOfSquares = 0;
            long squareOfSums = 0;
            for (int i=1; i<=n; i++)
            {
                sumOfSquares += i*i;
                squareOfSums += i;
            }
            squareOfSums *= squareOfSums;
            Console.WriteLine(squareOfSums - sumOfSquares);
        }
    }
}
