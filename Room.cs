// File: Room.cs
// Date: December 25, 2024

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Navigation property for Bookings
    public List<Booking> Bookings { get; set; } = new List<Booking>();

    // Navigation property for HotelStaff
    public List<HotelStaff> HotelStaff { get; set; } = new List<HotelStaff>();

    // Add CreatedAt property to store the date the room was created
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Automatically set to current date and time
}
