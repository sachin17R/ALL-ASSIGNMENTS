using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assaignment_ConsoleApp
{
    class Assaignment7_prime
    {
        public static Boolean PrimeFunc(int number)
        {
            bool flag = true;
            for(int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    flag = false;
                }
            }
            return flag;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                int number = help.number("enter the number");
                bool res = PrimeFunc(number);
                Console.WriteLine(res);
                Console.WriteLine(number +" is prime number");
            }
        }
    }
}
