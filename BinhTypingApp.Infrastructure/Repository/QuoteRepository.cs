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
            var quote = _context.Quotes.OrderBy(r => Guid.NewGuid()).Take(1).FirstOrDefault();
            if (quote == null)
                return "";

            return quote.QuoteValue;
        }
    }
}
