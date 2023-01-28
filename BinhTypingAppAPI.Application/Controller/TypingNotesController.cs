using BinhTypingApp.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinhTypingAppAPI.Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypingNotesController : ControllerBase
    {
        private IQuoteRepository _quoteRep;
        public TypingNotesController(IQuoteRepository quoteRepo) { 
            _quoteRep = quoteRepo;
        }

        [HttpGet]
        public async Task<string> Get()
        {

            return _quoteRep.GetRandomQuote();
        }
    }
}
