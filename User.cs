// File: User.cs
// Date: December 25, 2024

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int? LoyaltyProgramId { get; set; }
    public LoyaltyProgram? LoyaltyProgram { get; set; }

    // Navigation property for Bookings
    public List<Booking> Bookings { get; set; } = new List<Booking>();

    // Add CreatedAt property to store the date the user was created
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Automatically set to current date and time
}
