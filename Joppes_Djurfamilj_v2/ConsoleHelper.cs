using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Joppes_Djurfamilj_v2
{
    public static class ConsoleHelper
    {
        public static void Reloading()
        {
            Console.CursorVisible = false;
            for (int i = 0; i < 10; i++)
            {
                Console.Write("/");
                Thread.Sleep(50);
                Console.SetCursorPosition(0, Console.CursorTop);

                Console.Write("-");
                Thread.Sleep(50);
                Console.SetCursorPosition(0, Console.CursorTop);

                Console.Write("\\");
                Thread.Sleep(50);
                Console.SetCursorPosition(0, Console.CursorTop);

                Console.Write("|");
                Thread.Sleep(50);
                Console.SetCursorPosition(0, Console.CursorTop);
            }
            Console.CursorVisible = true;
        }

        public static void Sleep()
        {
            Thread.Sleep(1000);
        }

        public static void LineOutPut()
        {
            Console.WriteLine(new string('-', 80));
        }

        public static void ColorText(ConsoleColor color, string text)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = currentColor;
        }
    }
}
