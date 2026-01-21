namespace ECommerceBackend.Models;

public class ShoppingCart
{
    private readonly List<CartItem> _items = new();
    public IReadOnlyList<CartItem> Items => _items;

    public void AddItem(Product product, int quantity)
    {
        var existing = _items.FirstOrDefault(i => i.Product.Id == product.Id);
        if (existing != null)
            existing.Quantity += quantity;
        else
            _items.Add(new CartItem(product, quantity));
    }

    public decimal CalculateSubtotal() => _items.Sum(i => i.TotalPrice);

    public decimal CalculateDiscount(decimal rate) => CalculateSubtotal() * rate;

    public decimal CalculateTotal(decimal rate) => CalculateSubtotal() - CalculateDiscount(rate);

    public void Clear() => _items.Clear();
}
