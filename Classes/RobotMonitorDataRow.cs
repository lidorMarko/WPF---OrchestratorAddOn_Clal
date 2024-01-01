using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchestratorAddOn.Classes
{
    public class RobotMonitorDataRow
    {
        public string robotName { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string processName { get; set; }

        public string rowColor { get; set; }

        public RobotMonitorDataRow(string robotName, string startTime, string endTime, string processName)
        {
            this.robotName = robotName;
            this.startTime = startTime;
            this.endTime = endTime;
            this.processName = processName;

            if (processName.Equals(""))
                rowColor = "gray";
            else
                rowColor = "black";
        }
    }
}
