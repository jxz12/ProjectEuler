using System;
using System.Text;

class Solution
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = int.Parse(Console.ReadLine());

            int m = int.Parse(n.ToString().Substring(0,3));
            if (Palindromise(m) >= n)
            {
                m -= 1;
            }

            for (int i=m; i>=101; i--)
            {
                int palindrome = Palindromise(i);
                if (SmallestFactor(palindrome) != -1)
                {
                    Console.WriteLine(palindrome);
                    break;
                }
            }
        }
    }
    static int Palindromise(int input)
    {
        var sb = new StringBuilder();
        string inString = input.ToString();
        sb.Append(inString);
        for (int i=inString.Length-1; i>=0; i--)
        {
            sb.Append(inString[i]);
        }
        return int.Parse(sb.ToString());
    }
    static int SmallestFactor(int input)
    {
        for (int i=100; i<1000; i++)
        {
            if (input%i==0 && input/i<1000)
            {
                return i;
            }
        }
        return -1;
    }
}
