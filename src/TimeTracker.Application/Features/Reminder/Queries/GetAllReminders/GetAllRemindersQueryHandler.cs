using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Infrastructure;

namespace TimeTracker.Application.Features.Reminder.Queries.GetAllReminders
{

    public class GetAllRemindersQueryHandler : IRequestHandler<GetAllRemindersQueryRequest, List<GetAllRemindersQueryResponse>>
    {
        private readonly AppDbContext _context;

        public GetAllRemindersQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllRemindersQueryResponse>> Handle(GetAllRemindersQueryRequest request, CancellationToken cancellationToken)
        {
            return _context.Reminders.Select(r => new GetAllRemindersQueryResponse
            {
                Content = r.Content,
                SendAt = r.SendAt,
                To = r.To,
            }).ToList();
        }
    }
}
