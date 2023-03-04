
class Product
{
    public int Id;
    public string Name;

    public decimal Cost;
    public decimal Taxes;

}

class EnrichedProduct: Product
{
    public decimal Pret
    {
        get { return Cost + Cost * Taxes / 100; }
    }
}

class Program 
{
    static void Main() 
    {
        var p = new EnrichedProduct
        {
            Name = "Tricou",
            Cost = 150,
            Taxes=5
        };

        Console.WriteLine($"{p.Name} - {p.Pret} ");
    }
}

