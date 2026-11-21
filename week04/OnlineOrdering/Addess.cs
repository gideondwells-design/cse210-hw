public class Address
{
    public string _street;
    public string _city;
    public string _state;
    public string _country;

    public bool isInUSA()
    {
        return _country == "USA";
    }
    public string GetFullAddress(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
        return $"{_street}, {_city}, {_state}, {_country}";
    }
}