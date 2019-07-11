using System;

class Problem12
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());

        int[] allDivisors = AllDivisors(1000);
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Triangulate(allDivisors[n]));
        }
    }
    // store all answers
    static int[] AllDivisors(int n)
    {
        int[] allDivisors = new int[n+1];

        int i = 1;
        int numDivisors = 0;
        while (numDivisors <= n)
        {
            numDivisors = CountDivisors(Triangulate(++i));

            int j = Math.Min(n, numDivisors-1);
            while (j>=0 && allDivisors[j] == 0)
            {
                allDivisors[j--] = i;
            }
        }
        return allDivisors;
    }
    static int Triangulate(int n)
    {
        return (n*(n+1)) / 2;
    }
    static int CountDivisors(int n)
    {
        if (n == 1)
            return 1;

        int ans = 2;
        int sqrt = (int)Math.Sqrt(n); // do not calculate this every loop!
        for (int i=2; i<=sqrt; i++)
        {
            if (n%i == 0)
                ans += 2;
        }
        if (Math.Sqrt(n) == sqrt) // in case square
            ans -= 1;

        return ans;
    }
}
