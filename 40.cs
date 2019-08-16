using System;

class Problem40
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        while (t-- > 0)
        {
            int[] i_n = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            for (int i=0; i<7; i++)
            {
                Console.WriteLine(i_n[i]);
            }
        }
    }
}
