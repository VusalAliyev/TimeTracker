using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Application.Features.Reminder.Queries.GetSingleReminder
{
    public class GetSingleReminderQueryRequest:IRequest<GetSingleReminderQueryReponse>
    {
        public int Id { get; set; }
    }
}
