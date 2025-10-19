namespace ConsoleSelection.Utils;

public static class ClearConsoleUtil
{
    /// <summary>
    /// Clears the marked region inside the Console
    /// if top is not defined it will take the current Cursor position
    /// if toClear is not defined it will clear only the current line
    /// if width is not defined it will take the Window Width of the console
    /// </summary>
    /// <param name="top"></param>
    /// <param name="toClear"></param>
    /// <param name="left"></param>
    /// <param name="width"></param>
    public static void ClearRegion(int top = -1, int toClear = 1, int left = 0, int width = 0)
    {
        if (top == -1) 
            top = Console.CursorTop;

        string emptyLine = new string(' ', width == 0 ? Console.WindowWidth : width);
        
        for (int row = 0; row < toClear; row++)
        {
            Console.SetCursorPosition(left, row);
            Console.Write(emptyLine);
        }
        
        Console.SetCursorPosition(0, top);
    }
}