namespace ECommerceBackend.Models;

public abstract class Person
{
    public int Id { get; }
    public string Name { get; }

    protected Person(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
