using ECommerceBackend.Models;
using ECommerceBackend.Services;

namespace ECommerceBackend.UI;

public class Menu
{
    private readonly List<Product> _products;
    private readonly Customer _customer;
    private readonly IPayment _payment;
    private readonly DiscountService _discountService;
    private readonly OrderService _orderService;

    public Menu(List<Product> products, Customer customer, IPayment payment)
    {
        _products = products;
        _customer = customer;
        _payment = payment;
        _discountService = new DiscountService();
        _orderService = new OrderService(_payment, _discountService);
    }

    public void Show()
    {
        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Add Product to Cart");
            Console.WriteLine("3. View Cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. View Orders");
            Console.WriteLine("0. Exit");

            Console.Write("Choice: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1": ShowProducts(); break;
                case "2": AddToCart(); break;
                case "3": ShowCart(); break;
                case "4": Checkout(); break;
                case "5": ShowOrders(); break;
                case "0": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
private void ShowProducts()
{
    const int pageSize = 10;
    int currentPage = 0;
    int totalPages = (int)Math.Ceiling(_products.Count / (double)pageSize);

    while (true)
    {
        Console.Clear();
        Console.WriteLine($"Products (Page {currentPage + 1} of {totalPages})\n");

        int startIndex = currentPage * pageSize;

        for (int i = startIndex; i < startIndex + pageSize && i < _products.Count; i++)
        {
            var p = _products[i];
            Console.WriteLine($"{p.Id}. {p.Name} - {p.Price:0.00}€ | Stock: {p.Stock}");
        }

        Console.WriteLine("\n[n] Next page | [p] Previous page | [q] Quit");
        Console.Write("Choose: ");

        string input = Console.ReadLine()?.ToLower();

        if (input == "n" && currentPage < totalPages - 1)
            currentPage++;
        else if (input == "p" && currentPage > 0)
            currentPage--;
        else if (input == "q")
            break;
    }
}


    private void AddToCart()
    {
        Console.Write("Enter Product ID: ");
        int id = int.Parse(Console.ReadLine()!);

        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null) { Console.WriteLine("Product not found."); return; }

        Console.Write("Enter Quantity: ");
        int qty = int.Parse(Console.ReadLine()!);

        if (qty > product.Stock) { Console.WriteLine("Not enough stock."); return; }

        _customer.Cart.AddItem(product, qty);
        Console.WriteLine($"{qty} x {product.Name} added to cart.");
    }

    private void ShowCart()
    {
        Console.WriteLine("\nCart Items:");
        foreach (var item in _customer.Cart.Items)
            Console.WriteLine($"{item.Product.Name} x {item.Quantity} = {item.TotalPrice:0.00}€");

        Console.WriteLine($"Subtotal: {_customer.Cart.CalculateSubtotal():0.00}€");
    }

    private void Checkout()
    {
        if (!_customer.Cart.Items.Any()) { Console.WriteLine("Cart is empty."); return; }

        var order = _orderService.Checkout(_customer, _customer.Cart);
        foreach (var item in order.Items)
            item.Product.ReduceStock(item.Quantity);

        Console.WriteLine($"Order completed! Total: {order.TotalAmount:0.00}€");
    }

    private void ShowOrders()
    {
        if (!_customer.Orders.Any()) { Console.WriteLine("No orders yet."); return; }

        Console.WriteLine("\nOrders:");
        foreach (var o in _customer.Orders)
            Console.WriteLine(o);
    }
}
