using System.Runtime.InteropServices;

namespace SysCalls;

internal static unsafe class SystemFunctions
{
    [DllImport("User32.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
    public static extern int MessageBox(IntPtr handle, string text, string caption, uint type);

    [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
    public static extern bool GetCursorPos(POINT* point);

    [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
    public static extern bool SetCursorPos(int X, int Y);

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }

    public enum MessageBoxType : uint
    {
        MB_ABORTRETRYIGNORE = 0x00000002,
        MB_CANCELTRYCONTINUE = 0x00000006,
        MB_HELP = 0x00004000,
        MB_OK = 0x00000000,
        MB_OKCANCEL = 0x00000001,
        MB_RETRYCANCEL = 0x00000005,
        MB_YESNO = 0x00000004,
        MB_YESNOCANCEL = 0x00000003,
    }
}