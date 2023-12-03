using System;

class Program {
    static void Main(string[] args) {
        var product1 = new Product("Laptop", 101, 999.99m, 1);
        var product2 = new Product("Headphones", 102, 49.99m, 2);

        var address = new Address("123 Main St", "New York", "NY", "USA");
        var customer = new Customer("John Doe", address);

        var order = new Order(customer);
        order.AddProduct(product1);
        order.AddProduct(product2);

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order.CalculateTotalCost():C}");
    }
}
