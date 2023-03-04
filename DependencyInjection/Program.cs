class Format : IText
{
    public void print()
    {
        Console.WriteLine("Here is text format");
    }
}

public interface IText
{
    public void print();
}

public class ConstructorInInjection
{
    private IText _text;

    public ConstructorInInjection(IText t1)
    {
        this._text = t1;
    }

    public void print() 
    {
        _text.print();
    }
}

class Program {
    static void Main()
    {
        var obj = new ConstructorInInjection(new Format());
        obj.print();
    }
}