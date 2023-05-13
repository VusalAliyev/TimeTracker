using Microsoft.Extensions.Hosting;
using System.Text.Json;
using TimeTracker.Domain.Entities;
using TimeTracker.WebUI.Services.Interfaces;

namespace TimeTracker.WebUI.Services
{
    public class ReminderService : IReminderService
    {
        private readonly HttpClient _httpClient;

        public ReminderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Reminder>> GetAllReminder()
        {
            var response = await _httpClient.GetAsync("http://localhost:5109/api/Reminder");
            var reminderJson = await response.Content.ReadAsStringAsync();

            var reminders = JsonSerializer.Deserialize<List<Reminder>>(reminderJson);

            return reminders;

        }
    }
}
