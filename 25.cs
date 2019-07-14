using System;
// using System.Numerics;

class Problem25
{
    static void Main(string[] args)
    {
        int[] all = AllFibonacciDigits(5000, 5);

        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());
            
            Console.WriteLine(all[n]);
        }
    }
    static int[] AllFibonacciDigits(int n, int power=5)
    {
        int[] minDigits = new int[n+1];

        int[] fib1 = new int[n/power];
        int[] fib2 = new int[n/power];
        fib1[0] = fib2[0] = 1;

        int prevDigits = 1; // means that digit=1 is ignored, but spec allows this
        int term = 3;
        while (prevDigits < n)
        {
            int newDigits;
            if (term % 2 == 0)
            {
                newDigits = Add(fib1, fib2, power);
            }
            else
            {
                newDigits = Add(fib2, fib1, power);
            }

            if (newDigits > prevDigits)
            {
                minDigits[newDigits] = term;
                prevDigits = newDigits;
            }

            term += 1;
        }
        return minDigits;

        /* BigInteger below is too slow! */
        // BigInteger fib = 1;
        // BigInteger fib2 = 1;
        // while (prevDigits < n)
        // {
        //     int newDigits;
        //     if (term % 2 == 0)
        //     {
        //         fib += fib2;
        //         newDigits = fib.ToString().Length;
        //     }
        //     else
        //     {
        //         fib2 += fib;
        //         newDigits = fib2.ToString().Length;
        //     }

        //     if (newDigits > prevDigits)
        //     {
        //         minDigits[newDigits] = term;
        //         prevDigits = newDigits;
        //     }

        //     term += 1;
        // }
        // return minDigits;
    }

    // adds b to a, and returns number of digits in a
    // power increases the size of the digit as a power of 10
    // (like hex times binary by 4)
    static int Add(int[] a, int[] b, int power)
    {
        int n = a.Length;
        bool carry = false;
        int myBase = (int)Math.Pow(10, power);

        int digits = a.Length-1;
        while (a[digits] == 0 && b[digits] == 0)
        {
            digits -= 1;
        }

        int i;
        for (i=0; i<=digits; i++)
        {
            int sum = a[i] + b[i] + (carry?1:0);
            a[i] = sum % myBase;
            carry = sum >= myBase;
        }
        if (carry && i<a.Length)
        {
            a[i] = 1;
            i += 1;
        }
        
        // Math.Log() is stupid
        int ans = (i-1)*power;
        for (int j=0; j<power; j++)
        {
            if (a[i-1] >= (int)Math.Pow(10, j))
            {
                ans += 1;
            }
        }
        return ans;
    }
}
