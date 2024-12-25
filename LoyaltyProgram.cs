// File: LoyaltyProgram.cs
// Date: December 25, 2024

public class LoyaltyProgram
{
    public int Id { get; set; }
    public string ProgramName { get; set; } = string.Empty;

    // Navigation property for Users
    public List<User> Users { get; set; } = new List<User>();

    // Add CreatedAt property to store the date the loyalty program was created
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Automatically set to current date and time
}
