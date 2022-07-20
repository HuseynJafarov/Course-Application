using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Helpers
{
    public class Helpers
    {
        public static void WriteConsole(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();


        }
            
    }
}
