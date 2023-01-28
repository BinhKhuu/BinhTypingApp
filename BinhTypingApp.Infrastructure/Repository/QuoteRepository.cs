using BinhTypingApp.Domain.Repositories;
using BinhTypingApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinhTypingApp.Infrastructure.Repository
{
    public class QuoteRepository : IQuoteRepository
    {
        private BinhTypingAppDbContext _context;
        public QuoteRepository(BinhTypingAppDbContext context) {
            _context = context; 
        }
        public string GetRandomQuote()
        {
            // this does not work for non MS SQL so its an issue for testing
            // var quote = _context.Quotes.OrderBy(r => Guid.NewGuid()).Take(1).FirstOrDefault();

            // works on all db types
            Random rand = new Random();
            int toSkip = rand.Next(0, _context.Quotes.Count());
            var quote = _context.Quotes.Skip(toSkip).Take(toSkip).FirstOrDefault();


            if (quote == null)
                return "";

            return quote.QuoteValue;
        }
    }
}
