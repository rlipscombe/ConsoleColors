using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleColors.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleEx.SetColor(ConsoleColor.DarkYellow, Color.Gold);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var info = GetConsoleScreenBufferInfoEx();
            Console.WriteLine(info);
            Thread.Sleep(500);

            ConsoleEx.SetColor(ConsoleColor.Black, Color.DarkOliveGreen);
            info = GetConsoleScreenBufferInfoEx();
            Console.WriteLine(info);
            Thread.Sleep(500);

            ConsoleEx.SetColor(ConsoleColor.Black, Color.DarkSlateBlue);
            info = GetConsoleScreenBufferInfoEx();
            Console.WriteLine(info);
            Thread.Sleep(500);
        }

        private static CONSOLE_SCREEN_BUFFER_INFO_EX GetConsoleScreenBufferInfoEx()
        {
            var hConsoleOutput = NativeMethods.GetStdHandle(NativeMethods.STD_OUTPUT_HANDLE);
            var info = new CONSOLE_SCREEN_BUFFER_INFO_EX();
            info.cbSize = (uint) Marshal.SizeOf(info);
            if (!NativeMethods.GetConsoleScreenBufferInfoEx(hConsoleOutput, ref info))
                throw new Win32Exception();
            return info;
        }
    }
}
