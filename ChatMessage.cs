// File: ChatMessage.cs
// Date: December 25, 2024

public class ChatMessage
{
    public int Id { get; set; }
    public string UserMessage { get; set; } = string.Empty;
    public string BotResponse { get; set; } = string.Empty;
    public int BookingId { get; set; }

    // Mark Booking as required
    public required Booking Booking { get; set; }  // Added 'required' modifier

    // Add CreatedAt property to store the date the message was created
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
