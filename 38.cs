using System;

class Problem38
{
    static void Main(string[] args)
    {
        string[] split = Console.ReadLine().Split(' ');
        int N = int.Parse(split[0]);
        int K = int.Parse(split[1]);

        if (K == 8)
        {
            for (int i=2; i<=N; i++)
            {
                if (PanMultiple8(i)) Console.WriteLine(i);
            }
        }
        else
        {
            for (int i=2; i<=N; i++)
            {
                if (PanMultiple9(i)) Console.WriteLine(i);
            }
        }
    }
    static bool PanMultiple9(int multiplier)
    {
        int i=2;
        string s = multiplier.ToString();
        while (s.Length < 9) // get to 9 digits
        {
            s += (multiplier*i).ToString(); // slow I know
            i += 1;
        }
        return Pan9(s); 
    }
    static bool Pan9(string s)
    {
        if (s.Length > 9)
        {
            return false;
        }
        // this integer is used as a bitwise hashset
        int digits = 0;
        for (int i=0; i<9; i++)
        {
            int digit = s[i] - '0';
            if (digit == 0)
            {
                return false;
            }
            if (((digits >> digit) & 1) == 1) // appears twice
            {
                return false;
            }
            digits |= 1 << digit; // set to 1
        }
        return true;
    }
    static bool PanMultiple8(int multiplier)
    {
        int i=2;
        string s = multiplier.ToString();
        while (s.Length < 8) // get to 9 digits
        {
            s += (multiplier*i).ToString(); // slow I know
            i += 1;
        }
        return Pan8(s);
    }
    static bool Pan8(string s)
    {
        if (s.Length > 8)
        {
            return false;
        }
        // this integer is used as a bitwise hashset
        int digits = 0;
        for (int i=0; i<8; i++)
        {
            int digit = s[i] - '0';
            if (digit == 0 || digit == 9)
            {
                return false;
            }
            if (((digits >> digit) & 1) == 1) // appears twice
            {
                return false;
            }
            digits |= 1 << digit; // set to 1
        }
        return true;
    }
}
