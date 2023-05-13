using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Application.Features.Reminder.Commands.AddReminder;
using TimeTracker.Application.Features.Reminder.Commands.DeleteReminder;
using TimeTracker.Application.Features.Reminder.Commands.UpdateReminder;
using TimeTracker.Application.Features.Reminder.Queries.GetAllReminders;
using TimeTracker.Application.Features.Reminder.Queries.GetSingleReminder;

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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllRemindersQueryRequest requestModel)
        {
            List<GetAllRemindersQueryResponse> reminders = await _mediator.Send(requestModel);

            return Ok(reminders);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetSingleReminderQueryRequest requestModel)
        {
            GetSingleReminderQueryReponse reminder = await _mediator.Send(requestModel);
            return Ok(reminder);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateReminderCommandRequest requestModel)
        {
            CreateReminderCommandResponse reminder = await _mediator.Send(requestModel);
            return Ok(reminder);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteReminderCommandRequest  requestModel)
        {
            DeleteReminderCommandResponse reminder = await _mediator.Send(requestModel);
            return Ok("Reminder Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateReminderCommandRequest requestModel)
        {
            UpdateReminderCommandResponse reminder = await _mediator.Send(requestModel);
            return Ok(reminder);
        }
    }
}
