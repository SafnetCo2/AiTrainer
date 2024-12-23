public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    // Add a constructor that takes 3 arguments
    public Room(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }
}
