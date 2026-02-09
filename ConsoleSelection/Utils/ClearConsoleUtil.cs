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
    public static void ClearRegion(ref int top, int toClear = 1, int left = 0, int width = 0)
    {
        EnsureBufferHeight(toClear, ref top);
        
        if (top == -1) 
            top = Console.CursorTop;
        
        int bufferHeight = Console.WindowHeight;

        int rowsToClear = Math.Min(toClear, bufferHeight - top);

        if (rowsToClear <= 0)
        {
            Console.SetCursorPosition(left, Math.Min(top, bufferHeight - 1));
            return;
        }
        
        string emptyLine = new string(' ', width == 0 ? Console.WindowWidth : width);
        
        for (int row = 0; row < toClear; row++)
        {
            try
            {
                Console.SetCursorPosition(left, top + row);
                Console.Write(emptyLine);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Argument out of range");
                Console.ResetColor();
            }
        }
        
        Console.SetCursorPosition(left,Math.Min(top, bufferHeight - 1));
    }

    private static void EnsureBufferHeight(int rowsNeeded, ref int top)
    {
        int bufferHeight = Console.BufferHeight;

        if (top + rowsNeeded < bufferHeight) return;
        
        int linesToAdd = (top + rowsNeeded + 1) - bufferHeight;
        
        int safePosition = Math.Max(0, bufferHeight - 1);
        
        Console.SetCursorPosition(0, safePosition);
        
        for (int i = 0; i < linesToAdd; i++)
        {
            Console.WriteLine();
        }
        
        if (top >= safePosition)
        {
            top -= linesToAdd;
            top = Math.Max(0, top);
        }
    }
}