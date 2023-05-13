using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Application.Common;
using TimeTracker.Domain.Entities;
using TimeTracker.Infrastructure;

namespace TimeTracker.Application.Features.Reminder.Commands.AddReminder
{
    public class CreateReminderCommandHandler : IRequestHandler<CreateReminderCommandRequest, CreateReminderCommandResponse>
    {
        private readonly AppDbContext _context;
        private readonly IReminderBy _reminderBy;

        public CreateReminderCommandHandler(AppDbContext context, IReminderBy reminderBy)
        {
            _context = context;
            _reminderBy = reminderBy;
        }

        public async Task<CreateReminderCommandResponse> Handle(CreateReminderCommandRequest request, CancellationToken cancellationToken)
        {
            await _context.Reminders.AddAsync(new()
            {
                To = request.To,
                Content = request.Content,
                MethodType = request.MethodType,
                SendAt = request.SendAt
            });

            switch (request.MethodType)
            {
                case Domain.Enums.MethodType.Telegram:
                    _reminderBy.RemindByTelegram(request.To, request.Content);
                    break;
                case Domain.Enums.MethodType.Email:
                    _reminderBy.RemindByEmail(request.To, request.Content);
                    break;
                default:
                    break;
            }


            _context.SaveChangesAsync();

            return new CreateReminderCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
