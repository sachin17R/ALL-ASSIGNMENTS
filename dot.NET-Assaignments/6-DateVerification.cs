using System;
using Assaignment_ConsoleApp;


namespace Assaignment_ConsoleApp
{
    class DateVerificationApp
    {
        static Boolean isValidDate(int year, int month, int day)
        {
            if (((year % 400 == 0) || (year % 4 == 0)) && ((month >= 1 && month <= 12)))
            {
                if (month == 2)
                {
                    if (day >= 1 && day <= 29)
                    {
                        return true;
                    }
                }
                else if ((month == 1) || (month == 3) || (month == 5) || (month == 7) || (month == 8) || (month == 10) || (month == 12))
                {
                    if (day >= 1 && day <= 31)
                    {
                        return true;
                    }
                }
                else if ((month == 4) || (month == 6) || (month == 9) || (month == 11))
                {
                    if (day >= 1 && day <= 30)
                    {
                        return true;
                    }
                }


            }
            else if (month == 2)
            {
                if (day >= 1 && day <= 28)
                {
                    return true;
                }
            }
            else if ((month == 1) || (month == 3) || (month == 5) || (month == 7) || (month == 8) || (month == 10) || (month == 12))
            {
                if (day >= 1 && day <= 31)
                {
                    return true;
                }
            }
            else if ((month == 4) || (month == 6) || (month == 9) || (month == 11))
            {
                if (day >= 1 && day <= 30)
                {
                    return true;
                }
            }

            return false;
        }
        static void Main(string[] args)
        {
            int year = help.number("enter the year");
            int month = help.number("enter the month");
            int day = help.number("enter the day");

            Boolean result = isValidDate(year, month, day);

            if(result == true)
                Console.WriteLine("valid Date");
            else
                Console.WriteLine("invalid date broooooo");

        }
    }
}
