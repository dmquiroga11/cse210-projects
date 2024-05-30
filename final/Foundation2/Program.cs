using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ORDER 1 :");
        Product product1 = new Product("Producto 1", 101, 10.5m, 2);
        Product product2 = new Product("Producto 2", 102, 20.0m, 1);
        Product product3 = new Product("Producto 1", 103, 30.5m, 5);
        Product product4 = new Product("Producto 2", 104, 20.0m, 3);        
        Address address = new Address("123 Street", "Popayan", "Cauca", "Colombia");        
        Customer customer = new Customer("Diana Quiroga", address);
        
        Order order = new Order(new List<Product> { product1, product2 }, customer);        
        Console.WriteLine("Paking Label:");
        Console.WriteLine(order.GetPackagingLabel());        
        Console.WriteLine("\nShipping label:");
        Console.WriteLine(order.GetShippingLabel());        
        Console.WriteLine($"\nTotal Cost: {order.GetTotalCost()}");
        Console.WriteLine();

        Console.WriteLine("ORDER 2 :");               
        Order neworder = new Order(new List<Product> { product3, product4 }, customer);        
        Console.WriteLine("Paking Label:");
        Console.WriteLine(order.GetPackagingLabel());        
        Console.WriteLine("\nShipping label:");
        Console.WriteLine(order.GetShippingLabel());        
        Console.WriteLine($"\nTotal Cost: {neworder.GetTotalCost()}");
    }

    }

public class Product
{
    private string _name;
    private int _productId;
    private decimal _price;
    private int _amount;

    public Product(string name, int productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _amount = quantity;
    }

    public string GetName() { return _name; }
    public int GetId() { return _productId; }
    public decimal GetPrice() { return _price; }
    public int GetQuantity() { return _amount; }
    public decimal GetTotalCost() { return _price * _amount; }
}

public class Address
{
    private string _postalAddress;
    private string _city;
    private string _state;
    private string _country;

    public Address(string postalAddress, string city, string state, string country)
    {
        _postalAddress = postalAddress;
        _city = city;
        _state = state;
        _country = country;
    }

    public string GetPostalAddress() { return _postalAddress; }
    public string GetCity() { return _city; }
    public string GetState() { return _state; }
    public string GetCountry() { return _country; }
    public bool IsInUSA() { return _country.ToLower() == "usa"; }
    public string GetFullAddress() { return $"{_postalAddress}\n{_city}, {_state}\n{_country}"; }
}

public class Customer
{
    private string _name;
    private Address Address;

    public Customer(string name, Address address)
    {
        _name = name;
        Address = address;
    }

    public string GetName() { return _name; }
    public Address GetAddress() { return Address; }
    public bool LivesInUSA() { return Address.IsInUSA(); }
}

public class Order
{
    private List<Product> Products;
    private Customer Customer;

    public Order(List<Product> products, Customer customer)
    {
        Products = products;
        Customer = customer;
    }

    public decimal GetTotalCost()
    {
        decimal totalCost = Products.Sum(product => product.GetTotalCost());
        return totalCost + (Customer.LivesInUSA() ? 5 : 35);
    }

    public string GetPackagingLabel()
    {
        return string.Join("\n", Products.Select(product => $"{product.GetName()} ({product.GetId()})"));
    }

    public string GetShippingLabel()
    {
        return $"{Customer.GetName()}\n{Customer.GetAddress().GetFullAddress()}";
    }
}