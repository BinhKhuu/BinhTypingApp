using BinhTypingApp.Application.Domain.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;

namespace BinhTypingApp.Web.Pages
{
    public partial class TypingPage : ComponentBase
    {

        public string TypingNote { get; set; } = String.Empty;
        public string UserInput { get; private set; } = String.Empty;
        public TimeOnly TypingTimer { get; set; }
        public bool TypingStarted { get; set; }
        public string CurrentWord { get; set; } = String.Empty;

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
            CurrentWord = TypingNote.Length > 0 ? TypingNote.Split(" ")[0] : String.Empty;
        }

        public void OnUserTypeEvent(KeyboardEventArgs ev)
        {
            UserInput = $"{UserInput}{ev.Key}";
            TypingTimer = new TimeOnly();
            TypingStarted = true;
        }
    }
}
