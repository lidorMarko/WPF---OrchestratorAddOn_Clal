using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchestratorAddOn.Classes
{
    public class JobsData
    {
        private string processName;
        private string robots;

        public string ProcessName { get => processName; set => processName = value; }
        public string Robots { get => robots; set => robots = value; }

        public JobsData(string processName, string robots)
        {
            this.processName = processName;
            Robots = robots;
        }

    }
}
