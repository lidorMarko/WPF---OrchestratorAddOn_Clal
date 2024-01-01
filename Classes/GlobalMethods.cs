using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace OrchestratorAddOn.Classes
{
    class GlobalMethods
    {
        public static void AdjustDataGridMaxHeight(DataGrid myTable)
        {
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double tableHeaderHeight = myTable.PointToScreen(new Point(0, 0)).Y;
            myTable.MaxHeight = screenHeight - tableHeaderHeight;
        }
    }
}
