using System;
using System.Collections.Generic;

class Problem36
{
    static void Main(string[] args)
    {
        string[] split = Console.ReadLine().Split(' ');
        int N = int.Parse(split[0]);
        int K = int.Parse(split[1]);

        var p10s = Palindromes10(N-1);
        int ans = 0;
        foreach (int p10 in p10s)
        {
            if (IsPalindromeK(p10, K))
            {
                ans += p10;
            }
        }
        Console.WriteLine(ans);
    }
    static bool IsPalindromeK(int n, int K)
    {
        var baseK = new List<int>();
        while (n > 0)
        {
            baseK.Add(n % K);
            n /= K;
        }
        for (int i=0; i<baseK.Count/2; i++)
        {
            if (baseK[i] != baseK[baseK.Count-i-1])
            {
                return false;
            }
        }
        return true;
    }
    static List<int> Palindromes10(int max)
    {
        var palindromes = new List<int>();
        for (int i=1; i<=max; i++)
        {
            if (IsPalindrome10(i))
            {
                palindromes.Add(i);
            }
        }
        return palindromes;
    }
    static bool IsPalindrome10(int n)
    {
        string s = n.ToString();
        for (int i=0; i<s.Length/2; i++)
        {
            if (s[i] != s[s.Length-i-1])
            {
                return false;
            }
        }
        return true;
    }
}
