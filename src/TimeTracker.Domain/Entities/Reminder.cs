using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Domain.Enums;

namespace TimeTracker.Domain.Entities
{
    public class Reminder:BaseEntity
    {
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }
        public MethodType MethodType { get; set; }
    }
}
