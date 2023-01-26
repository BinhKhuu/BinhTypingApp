using BinhTypingApp.Application.Domain.Repository;
using System.Text.Json;

namespace BinhTypingApp.Web.HttpRepository
{
    public class TypingNotesHttpRepository : ITypingNotesHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public TypingNotesHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<string> Get()
        {
            var request = await _client.GetAsync($"{_client.BaseAddress}api/TypingNotes");
            var content = request.Content.ReadAsStringAsync();
            return content.Result;
        }
    }
}
