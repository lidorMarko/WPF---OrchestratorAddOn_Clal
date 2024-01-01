using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchestratorAddOn.Classes
{
   public enum FilterOptions
    {
        ReferenceStartsWith,
        ReferenceEndsWith,
        AnalyticsContains,
        SpecificContentContains
    }

    internal class LogsFilterSelection
    {
        public string folderName { get; set; }
        public FilterOptions Filter { get; set; }

        public string text; /*the text box text */

        public LogsFilterSelection(string folderName, FilterOptions filter,string text)
        {
            this.folderName = folderName;
            Filter = filter;
            this.text = text;
        }  
        public string tostring()
        {
            return  folderName + " " + text;
        }
    }
}
