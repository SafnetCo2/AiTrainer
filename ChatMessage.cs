namespace HotelChatbotBackend
{
    using Microsoft.EntityFrameworkCore;  // Required for Entity Framework operations
    using System.Collections.Generic;   // Required for List<T>

    public class ChatMessage
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public required string Message { get; set; }  // Marking as required

        // Static method to fetch all chat messages asynchronously
        public static async Task<List<ChatMessage>> GetChatMessagesAsync(HotelDbContext dbContext)
        {
            return await dbContext.ChatMessages.ToListAsync();
        }
    }
}
