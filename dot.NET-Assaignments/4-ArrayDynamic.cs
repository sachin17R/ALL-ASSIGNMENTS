using System;


namespace SampleConApp
{
    class Assaignment4Demo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the size of the array");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("enter the type of array as CTS name like SYSTEM.Arraytype");
            string typeName = Console.ReadLine();
            Type type = Type.GetType(typeName, true, true);
            Array myArray = Array.CreateInstance(type, size);

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"enter the values of {type.Name} type");
                string enteredvalue = Console.ReadLine();
                object convertedVlaue = Convert.ChangeType(enteredvalue, type);
                myArray.SetValue(convertedVlaue, i);
            }
            Console.WriteLine("values entered");
            Console.WriteLine();
            foreach (object item in myArray)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
    }
}
