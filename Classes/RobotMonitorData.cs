using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchestratorAddOn.Classes
{
    internal class RobotMonitorData
    {
        public string robotName { get; set; }
        public RobotMonitorDataRow[] robotMonitorDataRows { get; set; }

        public RobotMonitorData(string robotName, RobotMonitorDataRow[] robotMonitorDataRows)
        {
            this.robotName = robotName;
            this.robotMonitorDataRows = robotMonitorDataRows;
        }
    }
}
