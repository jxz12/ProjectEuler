using System;

class Problem1
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());

            // there are 7 numbers for each group of 15
            // for each further group, we therefore add 15*7 more things
            // plus the remaining 45

            var countSum = ThreeAndFiveNaive(3, 5, 0, 15);

            // arithmetic series
            long m = n/15;
            long factor = countSum.Item1 * 15;
            long series = (m*(m-1))/2 * factor; // triangular number

            long constant = countSum.Item2;
            series += m * constant;

            // left over
            long remainder = ThreeAndFiveNaive(3, 5, (n-n%15), n).Item2;

            Console.WriteLine(series + remainder);
        }
    }
    // does not have to be 3 and 5, can be anything
    static Tuple<int, long> ThreeAndFiveNaive(int three, int five, int start, int end)
    {
        int count = 0;
        long sum = 0;
        for (int i=start; i<end; i++)
        {
            if (i%three==0 || i%five==0)
            {
                count += 1;
                sum += i;
            }
        }
        return Tuple.Create(count, sum);
    }
}
