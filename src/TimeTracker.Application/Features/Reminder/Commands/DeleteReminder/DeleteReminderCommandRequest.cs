using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Application.Features.Reminder.Commands.DeleteReminder
{
    public class DeleteReminderCommandRequest:IRequest<DeleteReminderCommandResponse>
    {
        public int Id { get; set; }
    }
}
