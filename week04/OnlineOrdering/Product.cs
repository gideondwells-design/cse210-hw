public class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string ProductId
    {
        get => _productId;
        set => _productId = value;
    }

    public decimal Price
    {
        get => _price;
        set => _price = value;
    }

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetPackingLabelLine()
    {
        return $"{Name} ({ProductId}) x {Quantity}";
    }
}