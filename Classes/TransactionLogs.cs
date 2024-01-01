using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchestratorAddOn.Classes
{
    public class TransactionLogs
    {
         public string timespan { get; set; }
         public string level { get; set; }
         public string message { get; set; }

        public TransactionLogs(string timespan, string level, string logMessage)
        {
            this.timespan = timespan;
            this.level = level;
            this.message = logMessage;
        }
    }
}
