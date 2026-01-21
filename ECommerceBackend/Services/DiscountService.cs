using ECommerceBackend.Models;

namespace ECommerceBackend.Services;

public class DiscountService
{
    public decimal Apply(Customer customer, decimal total)
    {
        return customer.Type switch
        {
            CustomerType.Employee => total * 0.9m, // 10% discount
            _ => total
        };
    }
}
