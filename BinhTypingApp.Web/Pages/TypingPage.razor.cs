using Microsoft.AspNetCore.Components;

namespace BinhTypingApp.Web.Pages
{
    public partial class TypingPage : ComponentBase
    {

        public string TypingNote { get; set; } = String.Empty;

        [Parameter] 
        public Task<String> TypingQuoteService {  get; set; }

        protected override async void OnInitialized()
        {
            base.OnInitialized();
            await LoadTypingNote();
        }

        public async Task LoadTypingNote()
        {
            TypingNote = "This is a test note";
        }
    }
}
