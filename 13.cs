using System;

class Problem13
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        string sum = "";
        for(int a0 = 0; a0 < t; a0++)
        {
            string toAdd = Console.ReadLine();
            sum = Add(sum, toAdd);
        }
        Console.WriteLine(sum.Substring(0,10));
    }
    static string Add(string a, string b)
    {
        int n1 = a.Length, n2 = b.Length;
        string ans = "";
        bool carry = false;
        for (int i=0; i<Math.Max(n1,n2); i++)
        {
            int digit1 = i<n1? a[n1-1-i]-'0' : 0;
            int digit2 = i<n2? b[n2-1-i]-'0' : 0;

            int sum = digit1 + digit2 + (carry?1:0);
            if (sum >= 10)
            {
                sum -= 10;
                carry = true;
            }
            else
            {
                carry = false;
            }
            ans = sum.ToString() + ans; // yes, bad immutable
        }
        if (carry)
        {
            ans = "1" + ans;
        }
        return ans;
    }
}
