namespace ConsoleSelection.Interfaces;

public interface ISelectionMenu<out T>
{
    T Show();
}

public interface ICheckboxSelection<T>
{
    List<T> Show();
}