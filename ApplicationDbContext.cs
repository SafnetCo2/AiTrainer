using Microsoft.EntityFrameworkCore;

namespace HotelChatbotBackend
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ChatbotQuery> ChatbotQueries { get; set; }
    }

    public class ChatbotQuery
    {
        public int Id { get; set; }
        public required string Query { get; set; }
        public required string Response { get; set; }

        public ChatbotQuery(string query, string response)
        {
            Query = query;
            Response = response;
        }
    }
}
