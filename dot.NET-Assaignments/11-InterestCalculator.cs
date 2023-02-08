using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class _11_InterestValue
    {
        static void Main(string[] args)
        {
            while (true)
            {

                InterestCalcuLator();
            }
        }

        private static void InterestCalcuLator()
        {
            int price = Utilities.GetNumber("Enter the Principal Price in Rupees");
            int Time = Utilities.GetNumber("Enter the Time in terms Of Years");
            int Rate = Utilities.GetNumber("Enter the Rate in Terms of Number ");

            double result = (price * Time * Rate) / 100;

            Console.WriteLine("Interest Amount for your Data is : " + result);
        }
    }
}
