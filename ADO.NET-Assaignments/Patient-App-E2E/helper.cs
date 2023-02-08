using System;


namespace ADOConsoleApp
{
    class helper
    {
        public static int Number(string str)
        {
            int num = 0;
        RETRY:
            Console.WriteLine(str);
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("enter only non floating Numbers");
                goto RETRY;
            }
            return num;
        }

        public static string Text(string str)
        {
            Console.WriteLine(str);
            return (Console.ReadLine());
        }
    }
}
