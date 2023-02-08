using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorksApp
{
    class HelperClasses
    {
        public static int GetNumber(string qtn)
        {
            int number = 0;
        RETRY:
            Console.WriteLine(qtn);
            try
            {
                number = int.Parse(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter Only Non-Floating Numbers");
                Console.ForegroundColor = ConsoleColor.Black;

                goto RETRY;
            }
            return number;
        }
        public static double GetDouble(string qtn)
        {
            double number = 0;
        RETRY:
            Console.WriteLine(qtn);
            try
            {
                number = Convert.ToDouble(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter Only Floating Numbers");
                Console.ForegroundColor = ConsoleColor.Black;

                goto RETRY;
            }
            return number;
        }

        public static string GetValue(string qtn)
        {
            Console.WriteLine(qtn);
            string str = Console.ReadLine();
            return str;
        }
    }
}
