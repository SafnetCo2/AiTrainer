public class Room
{
    public int Id { get; set; }
    public string? Name { get; set; }  // Nullable
    public string? Description { get; set; }  // Nullable
    public decimal Price { get; set; }

    // Constructor to initialize Room with required properties
    public Room(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    // Parameterless constructor for Entity Framework
    public Room() { }
}
