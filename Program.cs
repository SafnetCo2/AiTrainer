using Microsoft.EntityFrameworkCore;
using HotelChatbotBackend;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Step 1: Configure database connection dynamically from environment variables
var connectionString = builder.Configuration.GetConnectionString("hotel_chatbot")
                       ?? Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING")
                       ?? throw new InvalidOperationException("Connection string not found.");

// Add DbContext service to the DI container with MySQL
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 23))));

// Step 2: Configure application to use environment-specified port
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}"); // Dynamically set port

// Add services to the container
builder.Services.AddControllers(); // Enable controllers if you plan to use them
builder.Services.AddEndpointsApiExplorer(); // For API documentation (Swagger)
builder.Services.AddSwaggerGen(); // Optional: Swagger documentation for the API

var app = builder.Build();

// Step 3: Setup Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger in development
    app.UseSwaggerUI(); // Swagger UI for browsing the API
}

// Enable static files if needed (e.g., for front-end assets)
app.UseStaticFiles();

app.UseRouting();

// Step 4: Setup Routes (API Endpoints)

// Basic Route for Health Check
app.MapGet("/", () => "Hotel Chatbot API Running!");

// Bookings Endpoint
app.MapGet("/bookings", async (HotelDbContext dbContext) =>
{
    var bookings = await dbContext.Bookings.Include(b => b.Room).Include(b => b.User).ToListAsync();
    return Results.Ok(bookings);
});

// Users Endpoints
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

// Loyalty Programs Endpoints
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

// Hotel Staff Endpoints
app.MapGet("/staff", async (HotelDbContext dbContext) =>
{
    var staff = await dbContext.HotelStaffs.ToListAsync();
    return Results.Ok(staff);
});

app.MapPost("/staff", async (HotelDbContext dbContext, HotelStaff staff) =>
{
    if (staff == null) return Results.BadRequest("Staff cannot be null.");
    dbContext.HotelStaffs.Add(staff);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/staff/{staff.Id}", staff);
});

// Run the application
app.Run();
