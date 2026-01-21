namespace ECommerceBackend.Services;

public interface IPayment
{
    bool ProcessPayment(decimal amount);
}
