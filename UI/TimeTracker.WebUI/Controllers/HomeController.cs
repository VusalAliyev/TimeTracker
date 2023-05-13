using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TimeTracker.Domain.Entities;
using TimeTracker.WebUI.Models;
using TimeTracker.WebUI.Services.Interfaces;

namespace TimeTracker.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReminderService _reminderService;

        public HomeController(ILogger<HomeController> logger, IReminderService reminderService)
        {
            _logger = logger;
            _reminderService = reminderService;
        }

        public async  Task<IActionResult> Index()
        {
            List<Reminder> reminders= await _reminderService.GetAllReminder();
            return View(reminders);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}