using Microsoft.EntityFrameworkCore;
using HotelChatbotBackend;

var builder = WebApplication.CreateBuilder(args);

// Step 1: Add DbContext to the service container and configure it to use MySQL
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("HotelDb"),
    new MySqlServerVersion(new Version(8, 0, 23)))); // Use the correct MySQL version

var app = builder.Build();

// Step 2: Setup Routes
app.MapGet("/", () => "Hotel Chatbot API Running!");

// Example route to access bookings (assuming you will later add controllers)
app.MapGet("/bookings", async (HotelDbContext dbContext) =>
{
    var bookings = await dbContext.Bookings.Include(b => b.Room).ToListAsync();
    return Results.Ok(bookings);
});

// Run the application
app.Run();
