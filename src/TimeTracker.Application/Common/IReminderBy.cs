using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Application.Common
{
    public interface IReminderBy
    {
        void RemindByTelegram();
        void RemindByEmail(string to,string content);
    }
}
