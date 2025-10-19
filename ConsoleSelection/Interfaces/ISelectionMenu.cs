namespace ConsoleSelection.Interfaces;

public interface ISelectionMenu<out T>
{
    T Show();
}