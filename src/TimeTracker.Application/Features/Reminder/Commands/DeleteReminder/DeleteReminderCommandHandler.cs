using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Infrastructure;

namespace TimeTracker.Application.Features.Reminder.Commands.DeleteReminder
{
    public class DeleteReminderCommandHandler : IRequestHandler<DeleteReminderCommandRequest, DeleteReminderCommandResponse>
    {
        private readonly AppDbContext _context;

        public DeleteReminderCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteReminderCommandResponse> Handle(DeleteReminderCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedReminder=_context.Reminders.FirstOrDefault(r=>r.Id==request.Id);
            _context.Reminders.Remove(deletedReminder);

            await _context.SaveChangesAsync();

            return new DeleteReminderCommandResponse
            {
                IsSuccess=true
            };
        }
    }
}
