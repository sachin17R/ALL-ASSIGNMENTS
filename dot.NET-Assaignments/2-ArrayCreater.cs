using System;


namespace SampleConApp
{
    class Assaignment
    {
        static void Main(string[] args)
        {
            Console.WriteLine("assaignment 1");
            ////////////assiagnment-1  displaying ranges of datatypes////////////
            Console.WriteLine("Ranges of datatypes in .NET are :");
            Console.WriteLine($"byte \t{byte.MinValue} to {byte.MaxValue}");
            Console.WriteLine($"short \t{short.MinValue} to {short.MaxValue}");
            Console.WriteLine($"int \t{int.MinValue} to {int.MaxValue}");
            Console.WriteLine($"long \t{long.MinValue} to {long.MaxValue}");
            Console.WriteLine($"float \t{float.MinValue} to {float.MaxValue}");
            Console.WriteLine($"double \t{double.MinValue} to {double.MaxValue}");
            Console.WriteLine($"decimal \t{decimal.MinValue} to {decimal.MaxValue}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            /////////////assaignment 2 array odd and even numbers//////////
            Console.WriteLine("assaignment 2");
            Console.WriteLine("enter the size of array");
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];
            Console.WriteLine("enter the values of array");
            for(int i = 0; i < size; i++)
            {
               arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("-------------------");
            Console.WriteLine("odd elemnts in given array");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]%2 != 0)
                {
                    Console.Write(arr[i]+" ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("even elemnts in given array");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]%2 ==  0)
                {
                    Console.Write(arr[i] + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("assaignment 3");




        }
    }
}
