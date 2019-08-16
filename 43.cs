using System;
using System.Collections.Generic;

class Problem43
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        long ans = 0;
        Pandigitals(N, x=> ans += IsSubstringDivisible(x));
        Console.WriteLine(ans);
    }
    static void Pandigitals(int ndigits, Action<int[]> Foo)
    {
        var digits = new int[ndigits+1];
        for (int i=0; i<=ndigits; i++)
        {
            digits[i] = i;
        }
        _Pandigitals(digits, digits.Length, Foo);
    }
    // Heap's algorithm
    static void _Pandigitals(int[] digits, int k, Action<int[]> Foo)
    {
        if (k==1)
        {
            Foo(digits);
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
    static int[] primes = new int[] { -1,2,3,5,7,11,13,17,19 };
    static long IsSubstringDivisible(int[] digits)
    {
        for (int i=1; i<digits.Length-2; i++)
        {
            int sum = digits[i]*100 + digits[i+1]*10 + digits[i+2];
            if (sum % primes[i] != 0)
            {
                return 0;
            }
        }
        long num = digits[0];
        for (int i=1; i<digits.Length; i++)
        {
            num *= 10;
            num += digits[i];
        }
        return num;
    }
}
