using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assaignment_ConsoleApp
{
    class CalenderAssaignment
    {
        public static List<DateTime> GetDates(int year, int month)
        {
            var dates = new List<DateTime>();

            // Loop from the first day of the month until we hit the next month, moving forward a day at a time
            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                dates.Add(date);
            }
            Console.WriteLine(dates);
            return dates;
        }

        static void Main(string[] args)
        {
            CalenderAssaignment.GetDates(2022, 12);
           
        }
    }
}
