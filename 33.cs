using System;

class Problem33
{
    static void Main(string[] args)
    {
        // always one digit so this is okay
        string both = Console.ReadLine();
        int N = both[0] - '0';
        int K = both[2] - '0';

        int min = (int)Math.Pow(10, N-1);
        int max = (int)Math.Pow(10, N)-1;
        int topSum = 0;
        int botSum = 0;
        for (int top=min; top<=max-1; top++)
        {
            for (int bot=top+1; bot<max; bot++)
            {
                if (CanCancel(top, bot, K))
                {
                    // Console.WriteLine(top+" "+bot);
                    topSum += top;
                    botSum += bot;
                }
            }
        }
        Console.WriteLine(topSum + " " + botSum);
    }
    // if the top and bottom share more than K digits (not zeros)
    static bool CanCancel(int top, int bot, int K)
    {
        return _CanCancel(top.ToString(), bot.ToString(), K, top, bot);
    }
    static bool _CanCancel(string top, string bot, int K, int _top, int _bot)
    {
        if (K == 0)
        {
            int __top = int.Parse(top);
            int __bot = int.Parse(bot);
            return __top!=0 && __bot!=0 && __top*_bot == _top*__bot;
        }
        else
        {
            int n = top.Length;
            for (int i=0; i<n; i++)
            {
                for (int j=0; j<n; j++)
                {
                    if (top[i] == bot[j] && top[i] != '0' &&
                        _CanCancel(top.Remove(i,1), bot.Remove(j,1), K-1, _top, _bot))
                    {
                        // Console.WriteLine(top.Remove(i,1)+" "+bot.Remove(j,1));
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
