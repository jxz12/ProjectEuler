using System;
using System.Linq;

class Problem22
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());

        string[] names = new string[t];
        for (int a0 = 0; a0 < t; a0++)
        {
            names[a0] = Console.ReadLine();
        }
        names = names.OrderBy(s=>s).ToArray();

        // would be better if we used a Dictionary here
        // but requirements are forgiving
        
        int q = int.Parse(Console.ReadLine());
        for (int a1 = 0; a1 < q; a1++)
        {
            string name = Console.ReadLine();
            for (int i=0; i<t; i++)
            {
                if (names[i] == name)
                {
                    Console.WriteLine((i+1) * NameValue(name));
                    break;
                }
            }
        }
    }
    static int NameValue(string name)
    {
        int sum = 0;
        foreach (char c in name)
        {
            sum += c - 'A' + 1;
        }
        return sum;
    }
}
