using System;

namespace Assaignment_ConsoleApp
{
    class ReverseWordAssaignment
    {
        public static void Revering(string sentence)
        {
            string reversed = null;
            string[] split = sentence.Split();
            for (int i = split.Length - 1; i >= 0; i--)
            {
                reversed += split[i] + " ";
            }
            Console.WriteLine(reversed);
        }
        static void Main(string[] args)
        {
            while (true)
            {
                string data = help.text("enter the long sentence to be reverse\n");
                ReverseWordAssaignment.Revering(data);
            }
        }
    }
}
