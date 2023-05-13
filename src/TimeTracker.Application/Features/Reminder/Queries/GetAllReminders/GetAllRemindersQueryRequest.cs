using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Application.Features.Reminder.Commands.DeleteReminder;

namespace TimeTracker.Application.Features.Reminder.Queries.GetAllReminders
{
    public class GetAllRemindersQueryRequest:IRequest<List<GetAllRemindersQueryResponse>>
    {
    }
}
