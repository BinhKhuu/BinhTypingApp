using BinhTypingApp.Application.Domain.Repository;
using Microsoft.AspNetCore.Components;

namespace BinhTypingApp.Web.Pages
{
    public partial class TypingPage : ComponentBase
    {

        public string TypingNote { get; set; } = String.Empty;

        [Parameter] 
        public Task<String> TypingQuoteService {  get; set; }

        [Inject]
        public ITypingNotesHttpRepository _http {  get; set; }

        protected override async void OnInitialized()
        {
            base.OnInitialized();
            await LoadTypingNote();
            StateHasChanged();
        }

        public async Task LoadTypingNote()
        {

            TypingNote = await _http.Get();
        }
    }
}
