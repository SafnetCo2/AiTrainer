// File: HotelStaff.cs
// Date: December 25, 2024

public class HotelStaff
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Navigation property for Rooms
    public List<Room> Rooms { get; set; } = new List<Room>();

    // Add CreatedAt property to store the date the staff member was added
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Automatically set to current date and time
}
