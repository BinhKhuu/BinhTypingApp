using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinhTypingApp.Domain.Repositories
{
    public interface IQuoteRepository
    {
        string GetRandomQuote();
    }
}
