namespace ECommerceBackend.Services;

public class FakePayment : IPayment
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Payment of {amount}€ processed successfully.");
        return true;
    }
}
