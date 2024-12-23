using Microsoft.EntityFrameworkCore;  // Required for DbContext and DbSet<>
using HotelChatbotBackend;  // Ensure this import for all the entities

public class HotelDbContext : DbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<User> Users { get; set; }  // Add DbSet for User
    public DbSet<LoyaltyProgram> LoyaltyPrograms { get; set; }  // Add DbSet for LoyaltyProgram
    //public DbSet<Staff> Staffs { get; set; }

    public DbSet<HotelStaff> HotelStaffs { get; set; }  // Add DbSet for HotelStaff

    // Constructor to pass the options to the base class
    public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }
}
