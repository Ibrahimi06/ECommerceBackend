namespace ECommerceBackend.Models;

public class Customer : Person
{
    public CustomerType Type { get; }
    public ShoppingCart Cart { get; }
    public List<Order> Orders { get; }

    public Customer(int id, string name, CustomerType type)
        : base(id, name)
    {
        Type = type;
        Cart = new ShoppingCart();
        Orders = new List<Order>();
    }

    public virtual decimal GetDiscountRate()
    {
        return 0m;
    }

    public void AddOrder(Order order)
    {
        Orders.Add(order);
    }
}
