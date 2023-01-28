using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinhTypingApp.Domain.Repositories;
using BinhTypingAppAPI.Application.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BinhTypingApp.Tests.Controller.Tests
{
    public class TypingAPITests
    {
        private ControllerContext controllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext()
        };


        [Fact]
        public async void ItShouldReturnQuote()
        {
            // Arrange
            var mockRepo = new Mock<IQuoteRepository>();
            mockRepo.Setup(repo => repo.GetRandomQuote())
                .Returns("TEST");
            var typingNotesController = new TypingNotesController(mockRepo.Object);
            // Act

            var results = await typingNotesController.Get();

            // Assert
            Assert.Equal("TEST", results);
        }
    }
}
