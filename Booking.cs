// File: Booking.cs
// Date: December 25, 2024

public class Booking
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public int UserId { get; set; }

    // Mark User as required
    public required User User { get; set; }  // Added 'required' modifier

    public int RoomId { get; set; }

    // Mark Room as required
    public required Room Room { get; set; }  // Added 'required' modifier

    // Navigation property for ChatMessages
    public List<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    // Add CreatedAt property to store the date the booking was created
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
