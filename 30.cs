using System;

class Problem30
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        long ans = N==3? SumAllSumDigits(x=>x*x*x)
                   :N==4? SumAllSumDigits(x=>x*x*x*x)
                   :N==5? SumAllSumDigits(x=>x*x*x*x*x)
                   :N==6? SumAllSumDigits(x=>x*x*x*x*x*x)
                   : 0; // need C# 7 to throw exception :(
        
        Console.WriteLine(ans);
    }
    static long SumAllSumDigits(Func<long, long> Pow)
    {
        long sum = 0;
        for (long n=2; n<=1000000; n++) // lol
        {
            if (IsSumOfDigits(n, Pow))
            {
                sum += n;
            }
        }
        return sum;
    }
    static bool IsSumOfDigits(long number, Func<long, long> Pow)
    {
        long sum = 0;
        long n = number;
        while (n > 0)
        {
            sum += Pow(n % 10);
            n /= 10;
        }
        return sum == number;
    }
}
