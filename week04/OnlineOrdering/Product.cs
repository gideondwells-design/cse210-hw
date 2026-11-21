public class Product
{
    public string _name;
    public string _product;
    public decimal _price;
    public int _quantity;

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }
}