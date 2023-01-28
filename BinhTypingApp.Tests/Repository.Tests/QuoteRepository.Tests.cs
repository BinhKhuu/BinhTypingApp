using BinhTypingApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using BinhTypingApp.Infrastructure.Data;
using BinhTypingApp.Infrastructure.Repository;
using BinhTypingApp.Domain.Models;

namespace BinhTypingApp.Tests.Repository.Tests
{

    // following this guide for repo testing https://code-maze.com/testing-repository-pattern-entity-framework/
    public class QuoteRepositoryTests
    {


        public static void InitializeQuoteData(BinhTypingAppDbContext context)
        {
            if (context.Quotes.Any())
            {
                return; // DB has been seeded
            }

            var smapleLang = new Language()
            {
                Language1 = "en",

            };
            var sampleQuote = new Quote()
            {
                QuoteId = new Guid(),
                QuoteValue = "TEST",
                QuoteSource = "Binh",
                QuoteLength = null,
                QuoteLanguage = "Engrish",
                QuoteSize = "Short",
                QuoteLanguageNavigation = smapleLang

            };
            context.Languages.Add(smapleLang);
            context.Quotes.Add(sampleQuote);
            context.SaveChanges();
        }

        [Fact]
        public void ItShouldGetRandomQuote()
        {
            var _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            var _contextOptions = new DbContextOptionsBuilder<BinhTypingAppDbContext>()
                .UseSqlite(_connection)
                .Options;

            using var context = new BinhTypingAppDbContext(_contextOptions);
            if (context.Database.EnsureCreated())
            {
                InitializeQuoteData(context);
                var quoteRepo = new QuoteRepository(context);
                var quote = quoteRepo.GetRandomQuote();
                Assert.NotNull(quote);
            }
                
        }
    }
}
