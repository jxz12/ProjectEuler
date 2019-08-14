using System;
using System.Collections.Generic;

class Problem32
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine(PandigitalProductSum(N));
    }
    static int PandigitalProductSum(int nDigits)
    {
        var permutation = new List<int>();
        for (int i=1; i<=nDigits; i++)
        {
            permutation.Add(i);
        }
        var found = new HashSet<int>();
        Permute(permutation, permutation.Count, ()=>CheckProduct(permutation, found));

        int ans = 0;
        foreach (int product in found)
        {
            ans += product;
        }
        return ans;
    }
    static void CheckProduct(List<int> permutation, HashSet<int> found)
    {
        int n = permutation.Count;

        // try all possible positions for multiply and equals operators
        for (int mult=0; mult<n-2; mult++)
        {
            for (int equal=mult+1; equal<n-1; equal++)
            {
                // construct numbers between operators
                int multiplicand = permutation[0];
                for (int i=1; i<=mult; i++)
                {
                    multiplicand *= 10;
                    multiplicand += permutation[i];
                }
                int multiplier = permutation[mult+1];
                for (int j=mult+2; j<=equal; j++)
                {
                    multiplier *= 10;
                    multiplier += permutation[j];
                }
                int product = permutation[equal+1];
                for (int k=equal+2; k<n; k++)
                {
                    product *= 10;
                    product += permutation[k];
                }
                if (multiplicand * multiplier == product)
                {
                    found.Add(product);
                }
            }
        }
    }
    // Heap's algorithm
    static void Permute(List<int> perm, int remaining, Action Foo)
    {
        if (remaining == 1)
        {
            // Foo is called on each permutation
            Foo();
        }
        for (int i=0; i<remaining; i++)
        {
            Permute(perm, remaining-1, Foo);
            if (remaining%2 == 1)
            {
                Swap(perm, 0, remaining-1);
            }
            else
            {
                Swap(perm, i, remaining-1);
            }
        }
    }
    static void Swap(List<int> l, int i, int j)
    {
        int temp = l[i];
        l[i] = l[j];
        l[j] = temp;
    }
}
