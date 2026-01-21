namespace ECommerceBackend.Models;

public class Product
{
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public int Stock { get; private set; }

    public Product(int id, string name, decimal price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public void ReduceStock(int quantity)
    {
        if (quantity > Stock)
            throw new InvalidOperationException("Not enough stock.");

        Stock -= quantity;

        if (Stock < 5)
            Console.WriteLine($"⚠ LOW STOCK: {Name}");
    }
}
