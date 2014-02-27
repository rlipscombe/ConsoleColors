using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ConsoleColors
{
    public static class ConsoleEx
    {
        public static void SetColor(ConsoleColor index, Color color)
        {
            SetColor((int)index, color.R, color.G, color.B);
        }

        private static void SetColor(int index, byte r, byte g, byte b)
        {
            IntPtr hConsoleOutput = NativeMethods.GetStdHandle(NativeMethods.STD_OUTPUT_HANDLE);
            if (hConsoleOutput == NativeMethods.INVALID_HANDLE_VALUE)
                throw new Win32Exception();

            var info = new CONSOLE_SCREEN_BUFFER_INFO_EX();
            info.cbSize = (uint) Marshal.SizeOf(info);
            if (!NativeMethods.GetConsoleScreenBufferInfoEx(hConsoleOutput, ref info))
                throw new Win32Exception();

            info.ColorTable[index] = new COLORREF(r,g,b);

            // WORKAROUND: srWindow is inclusive in Get, exclusive in Set, so the window shrinks each time:
            info.srWindow.Right += 1;
            info.srWindow.Bottom += 1;

            if(!NativeMethods.SetConsoleScreenBufferInfoEx(hConsoleOutput, ref info))
                throw new Win32Exception();
        }
    }
}