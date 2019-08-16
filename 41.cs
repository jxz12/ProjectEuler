using System;
using System.Collections.Generic;

class Problem41
{
    static void Main(string[] args)
    {
        var panPrimes = new List<int>();
        for (int i=1; i<=9; i++)
        {
            Pandigitals(i, x=> { if (IsPrime(x)) panPrimes.Add(x); });
        }
        panPrimes.Sort();

        int t = int.Parse(Console.ReadLine());
        while (t-- > 0)
        {
            long n = long.Parse(Console.ReadLine());
            if (panPrimes[0] > n)
            {
                Console.WriteLine("-1");
            }
            else
            {
                for (int i=panPrimes.Count-1; i>=0; i--)
                {
                    if (panPrimes[i] <= n)
                    {
                        Console.WriteLine(panPrimes[i]);
                        break;
                    }
                }
            }
        }
    }
    static void Pandigitals(int ndigits, Action<int> Foo)
    {
        var digits = new int[ndigits];
        for (int i=0; i<ndigits; i++)
        {
            digits[i] = ndigits-i;
        }
        _Pandigitals(digits, digits.Length, Foo);
    }
    // Heap's algorithm
    static void _Pandigitals(int[] digits, int k, Action<int> Foo)
    {
        if (k==1)
        {
            int n=digits[0];
            for (int i=1; i<digits.Length; i++)
            {
                n *= 10;
                n += digits[i];
            }
            Foo(n);
        }
        else
        {
            _Pandigitals(digits, k-1, Foo);
            for (int i=0; i<k-1; i++)
            {
                int temp = digits[k-1];
                if (k%2 == 0)
                {
                    digits[k-1] = digits[i];
                    digits[i] = temp;
                }
                else
                {
                    digits[k-1] = digits[0];
                    digits[0] = temp;
                }
                _Pandigitals(digits, k-1, Foo);
            }
        }
    }
    static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        if (n == 2) return true;
        if (n%2 == 0) return false;

        for (int x=3; x*x<=n; x+=2)
        {
            if (n%x == 0) return false;
        }
        return true;
    }
}
