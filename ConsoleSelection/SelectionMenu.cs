using ConsoleSelection.Interfaces;
using ConsoleSelection.Utils;

namespace ConsoleSelection;

public class SelectionMenu<T> : ISelectionMenu<T>
{
    private readonly IReadOnlyList<T> _items;
    private readonly string _title;
    private readonly Func<T, string>? _displaySelector;
    private int _index;

    /// <summary>
    /// If the item list is an object with defined keys, use the displaySelector variable to display the correct value
    /// Selection Menu uses the Items and the displaySelector to correctly display the selectable value
    /// The selection menu can be navigated using the up and down arrow keys or W and S
    /// </summary>
    /// <param name="items"></param>
    /// <param name="title"></param>
    /// <param name="displaySelector"></param>
    /// <exception cref="ArgumentException"></exception>
    public SelectionMenu(IEnumerable<T> items, Func<T, string>? displaySelector, string title = "Select an option")
    {
        _items = items.ToList();
        if (_items.Count == 0)
            throw new ArgumentException("Must have at least one item");

        _title = title;
        _index = 0;
        _displaySelector = displaySelector;
        
        Console.TreatControlCAsInput = true;
    }
    
    public T Show()
    {
        Console.WriteLine($"{_title}");
        SwitchIndex();
        return _items[_index];
    }

    private void SwitchIndex()
    {
        ConsoleKeyInfo key;
        (int _, int top) = Console.GetCursorPosition();
        
        do
        {
            ClearConsoleUtil.ClearRegion(top, _items.Count);
            
            RenderItem();
            
            key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    _index = _index == 0 ? _items.Count - 1 : _index - 1; 
                    break;
                case ConsoleKey.W:
                    _index = _index == 0 ? _items.Count - 1 : _index - 1; 
                    break;
                case ConsoleKey.DownArrow:
                    _index = _index == _items.Count - 1 ? 0 : _index + 1;
                    break;
                case ConsoleKey.S:
                    _index = _index == _items.Count - 1 ? 0 : _index + 1;
                    break;
            }
            
        } while (key.Key != ConsoleKey.Enter);
        
        // Removes the title at the end
        ClearConsoleUtil.ClearRegion(top - 1, _items.Count + 1);
    }

    private void RenderItem()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            var item = GetDisplayText(_items[i]);
            
            Console.WriteLine(i == _index ? $"[>] \x1b[4m{item}\x1b[24m" : $"[ ] {item}");
        }
    }

    private string GetDisplayText(T item) => _displaySelector?.Invoke(item) ?? item.ToString();
}