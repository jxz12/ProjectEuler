using System;

class Problem28
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine(Spiragonal(n/2));
        }
    }
    static long Spiragonal(long n)
    {
        // consecutive modulo to emulate commented
        // long a =  16 * ((2*n+1) * n * (n+1)) / 6; // sum of squares
        long a = ModMult(2, n) + 1;
        a = ModMult(a, n);
        a = ModMult(a, n+1);
        a = ModMult(a, 166666668); // modular multiplicative inverse of 6
        a = ModMult(a, 16);

        // long b = 4 * (n*(n+1))/2; // triangular numbers
        long b = ModMult(n, n+1);
        b = ModMult(b, 500000004); // MMI of 2
        b = ModMult(b, 4);

        // long c = 4 * MyMod(n);
        long c = ModMult(4, n);

        return MyMod(1+a+b+c);
    }
    static long ModMult(long a, long b)
    {
        return MyMod(MyMod(a) * MyMod(b));
    }
    static long MyMod(long x)
    {
        return x % 1000000007;
    }
}
