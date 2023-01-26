using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.ClientProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunit;
using System.Diagnostics.Metrics;
using BinhTypingApp.Web.Pages;
using Index = BinhTypingApp.Web.Pages.Index;
using Microsoft.AspNetCore.Components;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;

namespace BinhTypingApp.Tests.WebComponent.Tests
{
    public class TypingPageTests
    {

        private readonly string TYPINGMSG = "Typing Page";

        [Fact]
        public void ShouldLoadGreetingMessage()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Index>();
            var paraElm = cut.Find("h1");

            // Act
            var headingMessage = paraElm.TextContent;

            // Assert
            Assert.Equal("Hello, world!", headingMessage);
        }

        [Fact]
        public void ShouldLoadTypingPage()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Web.Pages.TypingPage>();
            var headingElement = cut.Find("h1");
            
            // ACT

            var typingPageMsg = headingElement.TextContent;

            // Assert
            Assert.Equal(TYPINGMSG, typingPageMsg);
        }

        [Fact]
        public void ShouldNavigateTypingPage()
        {
            using var ctx = new TestContext();
            var navMan = ctx.Services.GetRequiredService<FakeNavigationManager>();
            var cut = ctx.RenderComponent<Index>();
            navMan.NavigateTo("typingpage");
            Assert.Equal($"{navMan.BaseUri}typingpage", navMan.Uri);

        }

        [Fact]
        public void ItShouldLoadTypingNote()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Web.Pages.TypingPage>();
            

            // ACT

            cut.WaitForState(() =>  cut.Find("#TypingNote").TextContent.Length > 0, TimeSpan.FromSeconds(5));
            var typingNoteEle = cut.Find("#TypingNote").TextContent.Length;
            // Assert
            Assert.True(typingNoteEle > 0);
        }

    }
}
