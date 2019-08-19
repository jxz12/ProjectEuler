using System;

class Problem46
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        while (t-- > 0)
        {
            int n = int.Parse(Console.ReadLine());

            int ans = 0;
            for (int i=1; 2*i*i<n; i++)
            {
                if (IsPrime(n-2*i*i))
                {
                    ans += 1;
                }
            }
            Console.WriteLine(ans);
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
