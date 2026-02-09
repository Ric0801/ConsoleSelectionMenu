using ConsoleSelection.Interfaces;
using ConsoleSelection.Utils;

namespace ConsoleSelection;

public class CheckboxSelection<T> : ICheckboxSelection<T>
{
    private readonly IReadOnlyList<T> _items;
    private readonly List<T> _selectedItems = new List<T>();
    private readonly Func<T, string>? _displaySelector;
    private int _index;

    public CheckboxSelection(IReadOnlyList<T> items, Func<T, string>? displaySelector)
    {
        _items = items;
        if (_items.Count == 0)
            throw new ArgumentException("Must contain at least one item");
        
        _index = 0;
        _displaySelector = displaySelector;
    }
    
    public List<T> Show()
    {
        Console.WriteLine("Checkbox selection [Press SpaceBar to select]-[Press Enter to finish Selection]");
        SwitchIndex();
        return _selectedItems;
    }
    
    private void SwitchIndex()
    {
        ConsoleKeyInfo key;
        (int _, int top) = Console.GetCursorPosition();
        
        do
        {
            ClearConsoleUtil.ClearRegion(ref top, _items.Count);
            
            RenderItem();
            
            key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.Spacebar:
                    HandleSpaceBarPressed();
                    break;
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
        
        //removes the title
        int removeTitle = top - 1;
        ClearConsoleUtil.ClearRegion(ref removeTitle, _items.Count + 1);
        Console.WriteLine();
    }

    private void HandleSpaceBarPressed()
    {
        T item = _items[_index];
        
        if (_selectedItems.Count == 0)
        {
            _selectedItems.Add(item);
            return;
        };
        
        foreach (T entry in _selectedItems.ToList())
        {
            if (entry == null) continue; // entry should not be able to be null but Rider is crying

            if (entry.Equals(item))
            {
                _selectedItems.Remove(item);
                return;
            };
        }
        
        _selectedItems.Add(item);
    }
    
    private void RenderItem()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            var item = GetDisplayText(_items[i]);
            
            Console.WriteLine(i == _index ? $"{MarkCheckbox(_items[i], i)}  \x1b[4m{item}\x1b[24m" : $"{MarkCheckbox(_items[i], i)} {item}");
        }
    }

    private string MarkCheckbox(T item, int i)
    {
        bool selectedItem = false;

        foreach (T entry in _selectedItems)
        {
            if (entry == null || !entry.Equals(item)) continue;
            
            selectedItem = true;
            break;
        }
        
        if (selectedItem) return $"\x1b[7m[ ]\x1b[27m";
        return "[ ]";
    }

    private string GetDisplayText(T item) => _displaySelector?.Invoke(item) ?? item.ToString();

}