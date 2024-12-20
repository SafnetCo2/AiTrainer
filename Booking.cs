public class Booking
{
    public int Id { get; set; }
    public string? GuestName { get; set; }  // Nullable
    public int RoomId { get; set; }  // Foreign key to Room
    public Room? Room { get; set; }  // Nullable

    // Parameterless constructor for Entity Framework
    public Booking() { }

    // Constructor to create a Booking with a fully initialized Room
    public Booking(string guestName, string roomName, string roomDescription, decimal roomPrice)
    {
        GuestName = guestName;
        Room = new Room(roomName, roomDescription, roomPrice);  // Room initialized with all required properties
    }
}
