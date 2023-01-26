using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinhTypingApp.Application.Domain.Repository
{
    public interface ITypingNotesHttpRepository
    {
        Task<string> Get();
    }
}
