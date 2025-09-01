using SysCalls;

// unsafe
// {
//     int targetX = int.Parse(Console.ReadLine()!);
//     int targetY = int.Parse(Console.ReadLine()!);
//
//     SystemFunctions.POINT point = new SystemFunctions.POINT();
//
//     if (SystemFunctions.GetCursorPos(&point))
//     {
//         Console.WriteLine($"x: {point.x}");
//         Console.WriteLine($"y: {point.y}");
//     }
//
//     while (true)
//     {
//         bool incremented = false;
//
//         if (point.x < targetX)
//         {
//             point.x++;
//
//             incremented = true;
//         }
//
//         if (point.y < targetY)
//         {
//             point.y++;
//
//             incremented = true;
//         }
//
//         if (!incremented)
//         {
//             break;
//         }
//
//         SystemFunctions.SetCursorPos(point.x, point.y);
//         Thread.Sleep(10);
//     }
// }

var windowPtr = WindowFunctions.GetWindowByTitle("Analbek");

if (windowPtr != IntPtr.Zero)
{
    WindowFunctions.SetWindowTitle(windowPtr, Console.ReadLine()!);
}
else
{
    Console.WriteLine("Window not found.");
}