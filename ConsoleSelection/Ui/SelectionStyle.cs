using ConsoleSelection.Enums;

namespace ConsoleSelection.Ui;

internal class SelectionStyle
{
    private readonly Dictionary<ESelectionStyles, string> _stylingDict = new()
    {
        { ESelectionStyles.Default, "> " },
        { ESelectionStyles.Bold, "  \u001b[1m" },
        { ESelectionStyles.Cursive, "  \u001b[3m" },
        { ESelectionStyles.Underline, "  \u001b[4m" },
    };
    public string Reset => "\u001b[0m";
    public string this[ESelectionStyles style] => _stylingDict[style];
}