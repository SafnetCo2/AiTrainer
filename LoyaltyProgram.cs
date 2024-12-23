namespace HotelChatbotBackend
{
    public class LoyaltyProgram
    {
        public int Id { get; set; }

        public string? ProgramName { get; set; }  // Marking as nullable

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
