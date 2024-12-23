using Microsoft.EntityFrameworkCore;
using HotelChatbotBackend;

var builder = WebApplication.CreateBuilder(args);

// Step 1: Configure database connection dynamically
var connectionString = builder.Configuration.GetConnectionString("hotel_chatbot")
                       ?? throw new InvalidOperationException("Connection string 'hotel_chatbot' not found.");
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseMySql(connectionString,
    new MySqlServerVersion(new Version(8, 0, 23)))); // Use the correct MySQL version

// Step 2: Configure application to use environment-specified port
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

// Step 3: Setup Routes
app.MapGet("/", () => "Hotel Chatbot API Running!");

// Example route to access bookings (assuming you will later add controllers)
app.MapGet("/bookings", async (HotelDbContext dbContext) =>
{
    var bookings = await dbContext.Bookings.Include(b => b.Room).ToListAsync();
    return Results.Ok(bookings);
});

// Log application URL for Render deployment
Console.WriteLine($"Your application is live and listening on: http://localhost:{port}");

// Run the application
app.Run();
