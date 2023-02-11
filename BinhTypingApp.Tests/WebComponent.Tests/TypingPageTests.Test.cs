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
using Moq;
using BinhTypingApp.Application.Domain.Repository;
using BinhTypingApp.Web.HttpRepository;
using AngleSharp.Css.Dom;
using Microsoft.AspNetCore.Components.Web;

namespace BinhTypingApp.Tests.WebComponent.Tests
{
    public class TypingPageTests
    {

        //https://bunit.dev/docs/providing-input/inject-services-into-components.html
        internal class MockHttp : ITypingNotesHttpRepository
        {
            public async Task<string> Get()
            {

                return "TEST";
            }
        }

        private TestContext SetUpContext()
        {
            var ctx = new TestContext();
            ctx.Services.AddSingleton<ITypingNotesHttpRepository>(new MockHttp());
            return ctx;
        }

        private readonly string TYPINGMSG = "Typing Page";

        [Fact]
        public void ShouldLoadGreetingMessage()
        {
            // Arrange
            using var ctx = SetUpContext();
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
            using var ctx = SetUpContext();

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
            using var ctx = SetUpContext();

            var navMan = ctx.Services.GetRequiredService<FakeNavigationManager>();
            var cut = ctx.RenderComponent<Index>();
            navMan.NavigateTo("typingpage");
            Assert.Equal($"{navMan.BaseUri}typingpage", navMan.Uri);

        }

        [Fact]
        public void ItShouldLoadTypingNote()
        {
            // Arrange
            using var ctx = SetUpContext();
            var cut = ctx.RenderComponent<Web.Pages.TypingPage>();
            var component = cut.Instance;
            // ACT

            cut.WaitForState(() =>  cut.Find("#TypingNote").TextContent.Length > 0, TimeSpan.FromSeconds(5));
            var typingNoteEle = cut.Find("#TypingNote").TextContent.Length;
            var currentWord = component.CurrentWord;
            // Assert
            Assert.True(typingNoteEle > 0);
            Assert.True(currentWord.Length > 0);
        }

        [Fact]
        public void ItShouldLoadGridLayout() {
            using var ctx = SetUpContext();
            var cut = ctx.RenderComponent<Web.Pages.TypingPage>();
            var container = cut.Find("#TypingNoteContainer");

            // ACT



            // Assert
            Assert.True(container != null);
        }

        [Fact]
        public void ItShouldRenderHiddenInputHidden()
        {
            // Arrange
            using var ctx = SetUpContext();
            var cut = ctx.RenderComponent<Web.Pages.TypingPage>();
            // Act
            var hiddenInput = cut.Find("#HiddenUserInput");
            var inputStyles = hiddenInput.GetStyle();
            var displayValue = inputStyles.GetDisplay();
            var initalTextValue = hiddenInput.GetAttribute("value");
            // Assert
            Assert.NotNull(hiddenInput);
            Assert.NotEmpty(inputStyles);
            Assert.Equal("none", displayValue.ToString());
            Assert.Equal("", initalTextValue);
        }

        [Fact]
        public void WhenUserTypesTestIsIntitialized()
        {
            // Arrange
            using var ctx = SetUpContext();
            var cut = ctx.RenderComponent<Web.Pages.TypingPage>();

            // Act
            // user inputs value
            var hiddenInput = cut.Find("#HiddenUserInput");
            //hiddenInput.TriggerEvent("onChange", new Microsoft.AspNetCore.Components.ChangeEventArgs() { 
            //    Value = "T"
            //});

            hiddenInput.TriggerEvent("onkeypress", new KeyboardEventArgs()
            {
                Key = "T"
            });
            var component = cut.Instance;
            var userInputVaue = component.UserInput;
            var timer = component.TypingTimer;
            var isStarted = component.TypingStarted;
            
            // Assert
            Assert.True(userInputVaue == "T");
            Assert.True(isStarted);
            Assert.True(timer != null);
        }

        [Fact]
        public void WhenBackspaceIsTyped()
        {

        }

        [Fact]
        public void WhenInputMatchesCurrentWord()
        {

        }
    }
}
