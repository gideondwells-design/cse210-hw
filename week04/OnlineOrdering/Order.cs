public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public List<Product> Products
    {
        get => _products;
        set => _products = value;
    }

    public Customer Customer
    {
        get => _customer;
        set => _customer = value;
    }

    public decimal GetTotalCost()
    {
        decimal total = 0;
        foreach (Product product in Products)
        {
            total += product.GetTotalCost();
        }

        decimal shippingCost = Customer.IsInUSA() ? 5m : 35m;
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        return string.Join(Environment.NewLine, Products.Select(product => product.GetPackingLabelLine()));
    }

    public string GetShippingLabel()
    {
        return $"{Customer.Name}{Environment.NewLine}{Customer.Address.GetFullAddress()}";
    }
}