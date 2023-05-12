using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Infrastructure;

namespace TimeTracker.Application.Features.Reminder.Commands.AddReminder
{
    public class CreateReminderCommandHandler : IRequestHandler<CreateReminderCommandRequest, CreateReminderCommandResponse>
    {
        private readonly AppDbContext _context;

        public CreateReminderCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateReminderCommandResponse> Handle(CreateReminderCommandRequest request, CancellationToken cancellationToken)
        {
            await _context.Reminders.AddAsync(new()
            {
                To = request.To,
                Content = request.Content,
                MethodType=request.MethodType,
                SendAt = request.SendAt
            });
            _context.SaveChangesAsync();

            return new CreateReminderCommandResponse
            {
                IsSuccess=true
            };
        }
    }
}
