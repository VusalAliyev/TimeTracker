using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Application.Features.Reminder.Queries.GetAllReminders;
using TimeTracker.Infrastructure;

namespace TimeTracker.Application.Features.Reminder.Queries.GetSingleReminder
{
    public class GetSingleReminderQueryHandler : IRequestHandler<GetSingleReminderQueryRequest, GetSingleReminderQueryReponse>
    {
        private readonly AppDbContext _context;

        public GetSingleReminderQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetSingleReminderQueryReponse> Handle(GetSingleReminderQueryRequest request, CancellationToken cancellationToken)
        {
            var reminder= _context.Reminders.FirstOrDefault(r=>r.Id==request.Id);

            return new GetSingleReminderQueryReponse
            {
                Content=reminder.Content,
                SendAt=reminder.SendAt,
                To=reminder.To,
            };
        }
    }
}
