public class ChatMessage
{
    public int Id { get; set; }
    public required string UserMessage { get; set; } // Added required modifier
    public required string BotResponse { get; set; } // Added required modifier
    public DateTime Timestamp { get; set; }

    // Constructor to initialize non-nullable properties
    public ChatMessage(string userMessage, string botResponse)
    {
        UserMessage = userMessage;
        BotResponse = botResponse;
        Timestamp = DateTime.UtcNow; // Set the current timestamp
    }
}
