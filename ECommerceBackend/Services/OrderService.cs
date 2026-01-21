using ECommerceBackend.Models;

namespace ECommerceBackend.Services;

public class OrderService
{
    private readonly IPayment _payment;
    private readonly DiscountService _discountService;
    private static int _orderCounter = 1;

    public OrderService(IPayment payment, DiscountService discountService)
    {
        _payment = payment;
        _discountService = discountService;
    }

    public Order Checkout(Customer customer, ShoppingCart cart)
    {
        var discountedTotal = _discountService.Apply(customer, cart.CalculateSubtotal());

        if (!_payment.ProcessPayment(discountedTotal))
            throw new Exception("Payment failed");

        var order = new Order(_orderCounter++, cart.Items.ToList(), customer.GetDiscountRate());
        order.MarkPaid();

        customer.AddOrder(order);
        cart.Clear();

        return order;
    }
}
