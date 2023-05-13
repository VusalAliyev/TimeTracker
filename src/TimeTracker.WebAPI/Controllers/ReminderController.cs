using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Application.Features.Reminder.Commands.AddReminder;

namespace TimeTracker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReminderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateReminderCommandRequest requestModel)
        {
            CreateReminderCommandResponse reminder = await _mediator.Send(requestModel);
            return Ok(reminder);
        }
    }
}
