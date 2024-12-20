using Microsoft.AspNetCore.Mvc;

namespace HotelChatbotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatbotController : ControllerBase
    {
        // Example endpoint to handle chatbot requests
        [HttpGet("greet")]
        public IActionResult GetGreeting()
        {
            return Ok("Welcome to the Hotel Chatbot!");
        }

        // POST endpoint to handle user queries
        [HttpPost("ask")]
        public IActionResult AskQuestion([FromBody] string question)
        {
            // Logic to process the chatbot query goes here
            return Ok(new { response = $"You asked: {question}. This is a simulated response." });
        }
    }
}
