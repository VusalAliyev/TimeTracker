using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Application.Features.Reminder.Queries.GetAllReminders
{
    public class GetAllRemindersQueryResponse
    {
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }
    }
}
