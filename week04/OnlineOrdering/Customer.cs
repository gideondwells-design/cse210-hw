public class Customer
{
    public string _name;
    public Address _address;

    public bool isInUSA()
    {
        return _address.isInUSA();
    }
}