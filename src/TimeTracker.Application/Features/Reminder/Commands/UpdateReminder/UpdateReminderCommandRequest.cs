using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Domain.Enums;

namespace TimeTracker.Application.Features.Reminder.Commands.UpdateReminder
{
    public class UpdateReminderCommandRequest:IRequest<UpdateReminderCommandResponse>
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }
        public MethodType MethodType { get; set; }
    }
}
