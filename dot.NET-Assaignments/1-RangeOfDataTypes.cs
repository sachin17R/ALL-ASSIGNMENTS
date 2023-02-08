using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assaignment_ConsoleApp
{
    class RangeOfDatatypes
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Type                  Max-Range                      Min-Range");
            Console.WriteLine("Byte"+"--------------"+Byte.MaxValue +"------------"+ byte.MinValue);
            Console.WriteLine("Short"+"-------------"+short.MaxValue +"-----------"+ short.MinValue);
            Console.WriteLine("int"+"--------------"+int.MaxValue +"------------"+ int.MinValue);
            Console.WriteLine("long"+"--------------"+long.MaxValue +"------------"+ long.MinValue);
            Console.WriteLine("float"+"--------------"+float.MaxValue +"------------"+ float.MinValue);
            Console.WriteLine("double"+"--------------"+double.MaxValue +"------------"+ double.MinValue);
            Console.WriteLine("char"+"--------------"+char.MaxValue +"------------"+ char.MinValue);

        }
    }
}
