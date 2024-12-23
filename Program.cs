using Microsoft.EntityFrameworkCore;
using HotelChatbotBackend;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Step 1: Configure database connection dynamically from environment variables
var connectionString = builder.Configuration.GetConnectionString("hotel_chatbot")
                       ?? Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING")
                       ?? throw new InvalidOperationException("Connection string not found.");

// Add DbContext service to the DI container
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 23))));

// Step 2: Configure application to use environment-specified port
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}"); // Port is dynamically set

var app = builder.Build();

// Step 3: Setup Routes
app.MapGet("/", () => "Hotel Chatbot API Running!");

// Endpoints for Bookings
app.MapGet("/bookings", async (HotelDbContext dbContext) =>
{
    var bookings = await dbContext.Bookings.Include(b => b.Room).Include(b => b.User).ToListAsync();
    return Results.Ok(bookings);
});

// Endpoints for Users
app.MapGet("/users", async (HotelDbContext dbContext) =>
{
    var users = await dbContext.Users.Include(u => u.LoyaltyProgram).ToListAsync();
    return Results.Ok(users);
});

app.MapPost("/users", async (HotelDbContext dbContext, User user) =>
{
    if (user == null) return Results.BadRequest("User cannot be null.");

    dbContext.Users.Add(user);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/users/{user.Id}", user);
});

// Endpoints for LoyaltyPrograms
app.MapGet("/loyaltyprograms", async (HotelDbContext dbContext) =>
{
    var programs = await dbContext.LoyaltyPrograms.ToListAsync();
    return Results.Ok(programs);
});

app.MapPost("/loyaltyprograms", async (HotelDbContext dbContext, LoyaltyProgram program) =>
{
    if (program == null) return Results.BadRequest("Loyalty program cannot be null.");

    dbContext.LoyaltyPrograms.Add(program);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/loyaltyprograms/{program.Id}", program);
});
// Endpoints for HotelStaff
app.MapGet("/staff", async (HotelDbContext dbContext) =>
{
    var staff = await dbContext.HotelStaffs.ToListAsync();  // Fetching all staff from HotelStaffs DbSet
    return Results.Ok(staff);  // Returning the list of staff as an OK result
});

app.MapPost("/staff", async (HotelDbContext dbContext, HotelStaff staff) =>
{
    if (staff == null) return Results.BadRequest("Staff cannot be null.");  // Checking for null input

    dbContext.HotelStaffs.Add(staff);  // Adding new staff to the HotelStaffs DbSet
    await dbContext.SaveChangesAsync();  // Saving changes to the database
    return Results.Created($"/staff/{staff.Id}", staff);  // Returning a Created result with the staff's ID
});


// Log application URL for deployment
Console.WriteLine($"Your application is live and listening on: http://localhost:{port}");

// Run the application
app.Run();
