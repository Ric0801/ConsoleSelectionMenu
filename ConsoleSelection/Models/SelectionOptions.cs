using ConsoleSelection.Enums;

namespace ConsoleSelection.Models;

public class SelectionOptions<T>
{
    public required IEnumerable<T> Items { get; set; }
    public Func<T, string>? DisplaySelector { get; set; }
    public string? Title { get; set; }
    public ESelectionStyles Style { get; set; } = ESelectionStyles.Default;
}