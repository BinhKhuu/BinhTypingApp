using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinhTypingApp.Domain.Repositories;
using Moq;

namespace BinhTypingApp.Tests.Repository.Tests.Mocks
{
    internal class MockRepos
    {
        public static Mock<IQuoteRepository> GetMock()
        {
            var mock = new Mock<IQuoteRepository>();
            var mockQuote = "TEST";
            mock.Setup(m => m.GetRandomQuote()).Callback(() => { return mockQuote; });

            return mock;
        }
    }
}
