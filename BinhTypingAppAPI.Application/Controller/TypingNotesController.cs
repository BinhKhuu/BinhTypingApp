using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinhTypingAppAPI.Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypingNotesController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            return "This is a test notes 2";
        }
    }
}
