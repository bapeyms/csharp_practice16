namespace csharp_practice16;

public class MyButton
{
    // List<EventHandler> - список, у якому зберігаються всі методи, підписані на подію
    // EventHandler - стандартний тип делегата для обробки події
    // має два параметра: object sender, EventArgs e
    private List<EventHandler> _handlers = new List<EventHandler>();
    public event EventHandler Click
    {
        add
        {
            _handlers.Add(value);
        }
        remove
        {
            _handlers.Remove(value);
        }
    }

    public void Press()
    {
        Console.WriteLine("Button pressed!");
        foreach (EventHandler handler in _handlers)
        {
            // this передає сам об'єкт як sender
            // EventArgs.Empty передає порожні аргументи події
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyButton button = new MyButton();
        button.Click += ButtonClick1;
        button.Click += ButtonClick2;
        button.Press();
        
        Console.WriteLine("");
        button.Click -= ButtonClick1;
        button.Press();
    }

    static void ButtonClick1(object sender, EventArgs args)
    {
        Console.WriteLine("Button 1 clicked!");
    }

    static void ButtonClick2(object sender, EventArgs args)
    {
        Console.WriteLine("Button 2 clicked!");
    }
}