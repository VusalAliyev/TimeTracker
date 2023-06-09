﻿using Hangfire;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                    BackgroundJob.Schedule(() => _reminderBy.RemindByTelegram(request.To, request.Content), new DateTime(request.SendAt.Year, request.SendAt.Month, request.SendAt.Day, request.SendAt.Hour, request.SendAt.Minute, 0, DateTimeKind.Local));
                    break;
                case Domain.Enums.MethodType.Email:
                    BackgroundJob.Schedule(() => _reminderBy.RemindByEmail(request.To, request.Content), new DateTime(request.SendAt.Year, request.SendAt.Month, request.SendAt.Day, request.SendAt.Hour, request.SendAt.Minute, 0, DateTimeKind.Local));
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
