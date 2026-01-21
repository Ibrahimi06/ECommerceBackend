using ECommerceBackend.Models;
using ECommerceBackend.Services;
using ECommerceBackend.Data;
using ECommerceBackend.UI;

class Program
{
    static void Main()
    {
        var products = DataStore.Load<List<Product>>("products.json");

        if (products.Count == 0)
        {
            products.Add(new Product(1, "Laptop", 1200m, 10));
            products.Add(new Product(2, "Keyboard", 80m, 20));
            products.Add(new Product(3, "Mouse", 40m, 50));
        }

        Console.WriteLine("1. Regular Customer");
        Console.WriteLine("2. Employee Customer");
        int choice = int.Parse(Console.ReadLine()!);

        Customer customer = choice == 2
            ? new EmployeeCustomer(1, "Employee")
            : new Customer(1, "Customer", CustomerType.Regular);

        var menu = new Menu(products, customer, new FakePayment());
        menu.Show();

        DataStore.Save("products.json", products);
    }
}
