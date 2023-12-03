using System.Text;

class Order {
    private List<Product> Products { get; }
    private Customer OrderCustomer { get; }

    public Order(Customer customer) {
        OrderCustomer = customer;
        Products = new List<Product>();
    }

    public void AddProduct(Product product) {
        Products.Add(product);
    }

    public decimal CalculateTotalCost() {
        decimal total = Products.Sum(product => product.GetTotalPrice());
        decimal shippingCost = OrderCustomer.IsInUSA() ? 5 : 35;
        return total + shippingCost;
    }

    public string GetPackingLabel() {
        var builder = new StringBuilder();
        foreach (var product in Products) {
            builder.AppendLine($"{product.Name} (ID: {product.ProductId})");
        }
        return builder.ToString();
    }

    public string GetShippingLabel() {
        return $"{OrderCustomer.Name}\n{OrderCustomer.GetAddress()}";
    }
}
