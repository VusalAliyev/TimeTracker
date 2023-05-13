using TimeTracker.Domain.Entities;

namespace TimeTracker.WebUI.Services.Interfaces
{
    public interface IReminderService
    {
        Task<List<Reminder>> GetAllReminder();
    }
}
