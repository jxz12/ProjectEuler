using System;

class Problem19
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            string[] date1 = Console.ReadLine().Split(' ');
            string[] date2 = Console.ReadLine().Split(' ');

            long year1 = long.Parse(date1[0]);
            int month1 = int.Parse(date1[1]);
            int day1 = int.Parse(date1[2]);

            long year2 = long.Parse(date2[0]);
            int month2 = int.Parse(date2[1]);
            int day2 = int.Parse(date2[2]);

            // FixDate(ref day1, ref month1, ref year1);
            // FixDate(ref day2, ref month2, ref year2);

            if (day1 > 1)
            {
                month1 += 1;
                if (month1 > 12)
                {
                    month1 = 1;
                    year1 += 1;
                }
            }

            int numSundays = 0;
            if (year2 > year1)
            {
                // first year
                for (int month=month1; month<=12; month++)
                {
                    if (ZellerCongruence(year1, month, 1) == 1)
                    {
                        numSundays += 1;
                    }
                }
                // middle years
                for (long year=year1+1; year<=year2-1; year++)
                {
                    for (int month=1; month<=12; month++)
                    {
                        if (ZellerCongruence(year, month, 1) == 1)
                        {
                            numSundays += 1;
                        }
                    }
                }
                // last year
                for (int month=1; month<=month2; month++)
                {
                    if (ZellerCongruence(year2, month, 1) == 1)
                    {
                        numSundays += 1;
                    }
                }
            }
            else
            {
                for (int month=month1; month<=month2; month++)
                {
                    if (ZellerCongruence(year1, month, 1) == 1)
                    {
                        numSundays += 1;
                    }
                }
            }

            Console.WriteLine(numSundays);
        }
    }
    static void FixDate(ref int day, ref int month, ref long year)
    {
        if (month == 2)
        {
            if (year%4==0 && year%400!=0)
            {
                if (day > 29)
                {
                    day = 1;
                    month = 3;
                }
            }
            else
            {
                if (day > 28)
                {
                    day = 1;
                    month = 3;
                }
            }
        }
        if (month == 4 || month == 6 || month == 9 || month == 11)
        {
            if (day > 30)
            {
                day = 1;
                month += 1;
            }
        }
    }

    static int ZellerCongruence(long year, int month, int day)
    {
        if (month == 1 || month == 2)
        {
            year -= 1;
            month += 12;
        }

        int q = day;
        int m = month;
        long K = year%100;
        long J = year/100;

        return (int)((q + (13*(m+1))/5 + K + K/4 + J/4 + 5*J) % 7);
    }
}
