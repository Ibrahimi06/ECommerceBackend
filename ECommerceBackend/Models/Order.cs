namespace ECommerceBackend.Models;

public class Order
{
    public int OrderId { get; }
    public DateTime OrderDate { get; }
    public List<CartItem> Items { get; }
    public decimal TotalAmount { get; private set; }
    public bool IsPaid { get; private set; }

    public Order(int id, List<CartItem> items, decimal discountRate)
    {
        OrderId = id;
        OrderDate = DateTime.Now;

        Items = items; // store the cart items

        var subtotal = items.Sum(i => i.TotalPrice);
        var discount = subtotal * discountRate;
        TotalAmount = subtotal - discount;
    }

    public void MarkPaid() => IsPaid = true;

    public override string ToString() => $"Order #{OrderId} | {OrderDate:g} | Total: {TotalAmount:0.00}€";
}
