namespace HotelChatbotBackend
{
    public class HotelStaff
    {
        public int Id { get; set; }

        public required string Name { get; set; }  // Marking as required

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
