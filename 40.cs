using System;

class Problem40
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        while (t-- > 0)
        {
            long[] i_n = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            int ans = 1;
            for (int n=0; n<i_n.Length; n++)
            {
                ans *= Champernowne(i_n[n]-1) - '0';
            }
            Console.WriteLine(ans);
        }
    }
    static char Champernowne(long i)
    {
        // remove one 'set' of numbers at a time
        // a set is the sequence of numbers with the same no digits
        int nDigits = 0;
        while (i >= 0)
        {
            nDigits += 1;
            i -= nDigits * 9 * (long)Math.Pow(10, nDigits-1);
        }
        i += nDigits * 9 * (long)Math.Pow(10, nDigits-1);

        long order = i / nDigits; // its order within this set
        long digit = i % nDigits; // the digit within the number

        long number = (long)Math.Pow(10,nDigits-1) + order;

        return number.ToString()[(int)digit];
    }
}
