public class Order
{
    public List<Product> _products;
    public Customer _customer;

    public decimal GetTotalCost()
    {
        decimal total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }
        return total;
    }
    public string GetPackingLabel()
    {
        string label = "";
        foreach (Product product in _products)
        {
            label += $"{product._name}: {product._quantity}\n";
        }
        return label;
    }
    public string GetShippingLabel()
    {
        return $"{_customer._name}\n{_customer._address.GetFullAddress(_customer._address._street, _customer._address._city, _customer._address._state, _customer._address._country)}";
    }
}