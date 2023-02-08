using System;


namespace SampleConApp
{
    class Assaignment3Calci
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("enter the first value");
                int value1 = int.Parse(Console.ReadLine());
                Console.WriteLine("enter the operator : + , - , * , /");
                char input = char.Parse(Console.ReadLine());
                Console.WriteLine("enter the second value");
                int value2 = int.Parse(Console.ReadLine());

                if (input == '+')
                {
                    Console.WriteLine($"sum of {value1} and {value2} = " + (value1 + value2));
                    Console.WriteLine("-----*--------*-------*-------");
                    Console.WriteLine();
                }
                else if (input == '-')
                {
                    Console.WriteLine($"substraction of {value1} and {value2} = " + (value1 - value2));
                    Console.WriteLine("-----*--------*-------*-------");
                    Console.WriteLine();
                }
                else if (input == '*')
                {
                    Console.WriteLine($"multiplication of {value1} and {value2} = " + (value1 * value2));
                    Console.WriteLine("-----*--------*-------*-------");
                    Console.WriteLine();
                }
                else if (input == '/')
                {
                    Console.WriteLine($"division of {value1} and {value2} = " + (value1 / value2));
                    Console.WriteLine("-----*--------*-------*-------");
                    Console.WriteLine();
                }
            }
        }
    }
}
