using System;

class Program
{
    static void Main(string[] args)
    {
        Address domesticAddress = new Address
        {
            Street = "123 Main Street",
            City = "Rexburg",
            State = "Idaho",
            Country = "USA"
        };
        Address internationalAddress = new Address
        {
            Street = "45 Maple Road",
            City = "Toronto",
            State = "Ontario",
            Country = "Canada"
        };

        Customer domesticCustomer = new Customer
        {
            Name = "Jordan Lee",
            Address = domesticAddress
        };
        Customer internationalCustomer = new Customer
        {
            Name = "Alex Morgan",
            Address = internationalAddress
        };

        Product notebook = new Product { Name = "Notebook", ProductId = "N-101", Price = 4.50m, Quantity = 3 };
        Product pen = new Product { Name = "Pen", ProductId = "P-202", Price = 1.25m, Quantity = 4 };
        Product backpack = new Product { Name = "Backpack", ProductId = "B-303", Price = 32.00m, Quantity = 1 };
        Product headphones = new Product { Name = "Headphones", ProductId = "H-404", Price = 24.99m, Quantity = 2 };
        Product waterBottle = new Product { Name = "Water Bottle", ProductId = "W-505", Price = 12.50m, Quantity = 1 };
        Product planner = new Product { Name = "Planner", ProductId = "P-606", Price = 8.00m, Quantity = 2 };

        Order domesticOrder = new Order
        {
            Customer = domesticCustomer,
            Products = new List<Product> { notebook, pen, backpack }
        };
        Order internationalOrder = new Order
        {
            Customer = internationalCustomer,
            Products = new List<Product> { headphones, waterBottle, planner }
        };

        PrintOrder(domesticOrder);
        PrintOrder(internationalOrder);
    }

    private static void PrintOrder(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: {order.GetTotalCost():C}");
        Console.WriteLine();
    }
}