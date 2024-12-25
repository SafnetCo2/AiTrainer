// File: HotelDbContext.cs
// Date: December 25, 2024

using Microsoft.EntityFrameworkCore;

public class HotelDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<HotelStaff> HotelStaffs { get; set; }
    public DbSet<LoyaltyProgram> LoyaltyPrograms { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Define relationships here (no changes needed for CreatedAt)

        // User and LoyaltyProgram: One-to-Many
        modelBuilder.Entity<User>()
            .HasOne(u => u.LoyaltyProgram)
            .WithMany(l => l.Users)
            .HasForeignKey(u => u.LoyaltyProgramId)
            .OnDelete(DeleteBehavior.SetNull);

        // User and Booking: One-to-Many
        modelBuilder.Entity<User>()
            .HasMany(u => u.Bookings)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Booking and Room: Many-to-One
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Room)
            .WithMany(r => r.Bookings)
            .HasForeignKey(b => b.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        // Booking and ChatMessage: One-to-Many
        modelBuilder.Entity<Booking>()
            .HasMany(b => b.ChatMessages)
            .WithOne(c => c.Booking)
            .HasForeignKey(c => c.BookingId)
            .OnDelete(DeleteBehavior.Cascade);

        // Room and HotelStaff: Many-to-Many
        modelBuilder.Entity<Room>()
            .HasMany(r => r.HotelStaff)
            .WithMany(h => h.Rooms)
            .UsingEntity<Dictionary<string, object>>(
                "RoomHotelStaff",
                r => r.HasOne<HotelStaff>().WithMany().HasForeignKey("HotelStaffId"),
                h => h.HasOne<Room>().WithMany().HasForeignKey("RoomId")
            );
    }
}
