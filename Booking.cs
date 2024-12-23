namespace HotelChatbotBackend
{
    public class Booking
    {
        public int Id { get; set; }
        public string? GuestName { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }

        public Booking() { }

        public Booking(string guestName, string roomName, string roomDescription, decimal roomPrice)
        {
            GuestName = guestName;
            Room = new Room(roomName, roomDescription, roomPrice);
        }
    }
}
