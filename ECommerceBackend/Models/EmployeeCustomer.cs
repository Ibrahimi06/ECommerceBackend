namespace ECommerceBackend.Models;

public class EmployeeCustomer : Customer
{
    public EmployeeCustomer(int id, string name)
        : base(id, name, CustomerType.Employee)
    {
    }

    public override decimal GetDiscountRate()
    {
        return 0.10m; // 10% discount for employees
    }
}
