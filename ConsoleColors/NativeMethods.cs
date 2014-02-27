using System;
using System.Runtime.InteropServices;

namespace ConsoleColors
{
    public static class NativeMethods
    {
        public static int STD_OUTPUT_HANDLE = -11;    // per WinBase.h
        public static IntPtr INVALID_HANDLE_VALUE = (IntPtr) (-1);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern bool
            GetConsoleScreenBufferInfoEx(IntPtr hConsoleOutput,
                                         ref CONSOLE_SCREEN_BUFFER_INFO_EX lpConsoleScreenBufferInfoEx);
    
        [DllImport("kernel32", SetLastError = true)]
        internal static extern bool
            SetConsoleScreenBufferInfoEx(IntPtr hConsoleOutput,
                                         ref CONSOLE_SCREEN_BUFFER_INFO_EX lpConsoleScreenBufferInfoEx);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern IntPtr GetStdHandle(int nStdHandle);
    }

    // ReSharper disable InconsistentNaming
    // ReSharper disable FieldCanBeMadeReadOnly.Global
    // ReSharper disable MemberCanBePrivate.Global
    [StructLayout(LayoutKind.Sequential)]
    internal struct CONSOLE_SCREEN_BUFFER_INFO_EX
    {
        public uint cbSize;
        public COORD dwSize;
        public COORD dwCursorPosition;

        // Current character attributes (FOREGROUND_RED, etc.)
        [MarshalAs(UnmanagedType.U2)]
        public ushort wAttributes;

        public SMALL_RECT srWindow;
        public COORD dwMaximumWindowSize;
        
        // Popup attributes. No idea what that means...
        [MarshalAs(UnmanagedType.U2)]
        public ushort wPopupAttributes;
        
        [MarshalAs(UnmanagedType.Bool)]
        public bool bFullscreenSupported;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public COLORREF[] ColorTable;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct COORD
    {
        [MarshalAs(UnmanagedType.U2)] public ushort X;
        [MarshalAs(UnmanagedType.U2)] public ushort Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SMALL_RECT
    {
        [MarshalAs(UnmanagedType.U2)] public ushort Left;
        [MarshalAs(UnmanagedType.U2)] public ushort Top;
        [MarshalAs(UnmanagedType.U2)] public ushort Right;
        [MarshalAs(UnmanagedType.U2)] public ushort Bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct COLORREF
    {
        // Win32 has typedef DWORD COLORREF; we'll use a single nested member.
        internal uint value;

        public COLORREF(byte r, byte g, byte b)
        {
            value = From(r, g, b);
        }

        private static uint From(uint r, uint g, uint b)
        {
            return r + (g << 8) + (b << 16);
        }

        public byte R
        {
            get { return (byte) (value & 0xFF); }
        }

        public byte G
        {
            get { return (byte) ((value & 0xFF00) >> 8); }
        }

        public byte B
        {
            get { return (byte) ((value & 0xFF0000) >> 16); }
        }

        public override string ToString()
        {
            return string.Format("R: {0}, G: {1}, B: {2}", R, G, B);
        }
    }

    // ReSharper restore MemberCanBePrivate.Global
    // ReSharper restore FieldCanBeMadeReadOnly.Global
    // ReSharper restore InconsistentNaming
}