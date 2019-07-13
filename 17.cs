using System;

class Problem17
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            long n = long.Parse(Console.ReadLine());

            string number = n.ToString();
            PrintNumber(number);
        }
    }
    static void PrintNumber(string number)
    {
        if (number == "0")
        {
            Console.WriteLine(units[0]);
            return;
        }
        int hundred=0, ten=0, unit=0;
        // biggest digits first
        if (number.Length % 3 == 1)
        {
            unit = number[0] - '0';
            Console.Write(BelowHundred(0, unit));
        }
        else
        {
            if (number.Length % 3 == 0)
            {
                hundred = number[0] - '0';
                Console.Write(units[hundred] + " " + powers[0]);

                ten = number[1] - '0';
                unit = number[2] - '0';
                if (ten > 0 || unit > 0)
                {
                    Console.Write(" ");
                }
            }
            else
            {
                ten = number[0] - '0';
                unit = number[1] - '0';
            }
            Console.Write(BelowHundred(ten, unit));
        }

        // 4 = 1, 5 = 2. 6=3, 7=1, 8=2, 9=3
        int digit = (number.Length % 3);
        if (digit == 0)
        {
            digit = 3;
        }
        while (digit < number.Length)
        {
            if (digit <= 3 || hundred > 0 || ten > 0 || unit > 0)
            {
                int power = (number.Length-digit) / 3;
                Console.Write(" " + powers[power]);
            }

            hundred = number[digit] - '0';
            ten = number[digit+1] - '0';
            unit = number[digit+2] - '0';
            if (hundred > 0)
            {
                Console.Write(" " + units[hundred] + " " + powers[0]);
            }

            if (ten > 0 || unit > 0)
            {
                Console.Write(" ");
            }

            Console.Write(BelowHundred(ten, unit));
            digit += 3;
        }
        Console.Write("\n");
    }
    static string BelowHundred(int ten, int unit)
    {
        if (ten == 0)
        {
            if (unit > 0)
            {
                return units[unit];
            }
            else
            {
                return "";
            }
        }
        else if (ten == 1)
        {
            return teens[unit];
        }
        else
        {
            if (unit == 0)
            {
                return tens[ten-2];
            }
            else
            {
                return tens[ten-2] + " " + units[unit];
            }
        }
    }

    static string[] units = new string[] {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"};
    
    static string[] teens = new string[] {"Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};

    static string[] tens = new string[] {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
    
    static string[] powers = new string[] {"Hundred", "Thousand", "Million", "Billion", "Trillion"};
}
