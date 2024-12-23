using HotelChatbotBackend;  // Add this to fix the CS0246 error

namespace HotelChatbotBackend
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? LoyaltyProgramId { get; set; }
        public LoyaltyProgram? LoyaltyProgram { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public User(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
