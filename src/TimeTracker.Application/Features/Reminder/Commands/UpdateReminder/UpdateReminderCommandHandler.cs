using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Application.Features.Reminder.Commands.AddReminder;
using TimeTracker.Infrastructure;

namespace TimeTracker.Application.Features.Reminder.Commands.UpdateReminder
{
    public class UpdateReminderCommandHandler : IRequestHandler<UpdateReminderCommandRequest, UpdateReminderCommandResponse>
    {
        private readonly AppDbContext _context;

        public UpdateReminderCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateReminderCommandResponse> Handle(UpdateReminderCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedReminder =  _context.Reminders.FirstOrDefault(r => r.Id == request.Id);

            updatedReminder.SendAt = request.SendAt;
            updatedReminder.Content= request.Content;

            _context.SaveChanges();

            return new UpdateReminderCommandResponse
            {
                IsSuccess = true
            };



        }
    }
}
