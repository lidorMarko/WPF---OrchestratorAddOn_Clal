using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchestratorAddOn.Classes
{
    public class TransactionData
    {
        public string robotName { get; set; }
        public string processName { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string reference { get; set; }
        public TransactionLogs[] logs { get; set; }

        public TransactionData(string robotName, string processName, string startTime, string endTime,string reference, TransactionLogs[] logs)
        {
            this.robotName = robotName;
            this.processName = processName;
            this.startTime = startTime;
            this.endTime = endTime;
            this.reference = reference;
            this.logs = logs;
        }

        public string tostring()
        {
            return robotName + ":" + processName + ":" + startTime + ":" + endTime;
        }
    }
}
