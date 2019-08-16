using System;

class Problem1
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        while (t-- > 0)
        {
            long[] i_n = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            for (ing i=0; i<7; i++)
            {
                Console.WriteLine(i_n[i]);
            }
        }
    }
    static char Champernowne(long i)
    {
        // remove one 'set' of numbers at a time
        // a set is the sequence of numbers with the same no digits
        int nDigits = 0;
        while (i > 0)
        {
            nDigits += 1;
            i -= nDigits * 9 * (long)Math.Pow(10, i-1);
        }
        i += nDigits * 9 * (long)Math.Pow(10, i-1);

        long number = i / nDigits;
        long digit = i % nDigits;

        return number.ToString()[digit];
    }
}
