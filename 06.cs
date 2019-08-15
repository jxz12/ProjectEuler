using System;

class Problem6
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        while (t-- > 0)
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
