using OrchestratorAddOn.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OrchestratorAddOn.Queries;

namespace OrchestratorAddOn.Pages
{

    public partial class RobotsMonitor : Page
    {
        //public System.Collections.ObjectModel.ObservableCollection<string> Options { get; } =new ObservableCollection<string>();
        private string chooseRobotDefaultText = "robot";
        public RobotsMonitor()
        {
            InitializeComponent();
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker.Text.Equals("") || Choose_Robot.Content.ToString().Equals(chooseRobotDefaultText))
                return;

            //remove previous loading
            resultTable.Items.Clear(); //clear current table
            resultTable.Visibility = Visibility.Hidden;

            Loader.Visibility = Visibility.Visible;

            RobotMonitorDataRow[] robotSchedule = await DatabaseAccess.GetRobotSchedule(Choose_Robot.Content.ToString(),
                                                                     datePicker.SelectedDate.ToString());
            for (int i = 0; i < robotSchedule.Length; i++)
            {
                resultTable.Items.Add(robotSchedule[i]);
            }

            Loader.Visibility = Visibility.Hidden;
            resultTable.Visibility = Visibility.Visible;

            //Adjust table's max height
            GlobalMethods.AdjustDataGridMaxHeight(resultTable);
        }
        private void Close_buttonsPanel_Click(object sender, RoutedEventArgs e)
        {
            FilterButtonSelectionGrid.Visibility = Visibility.Hidden;
        }
        private void Choose_Robot_Click(object sender, RoutedEventArgs e)
        {
            string[] allRobots = DatabaseAccess.RetriveAllRobotNames();
            ButtonsWrapPanel.Children.Clear();
            for (int i = 0; i < allRobots.Length; i++)
            {
                Button button = new Button();
                button.Content = allRobots[i];
                button.Click += DynamicChooseRobotButton_Click;
                button.Style = (Style)FindResource("selectionButtons");

                //add the new button to the stackpanel
                ButtonsWrapPanel.Children.Add(button);
            }
            //set the buttons panel visibility and animate the entrance
            FilterButtonSelectionGrid.Visibility = Visibility.Visible;
            DoubleAnimation fadeInAnimation = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(1.5)));
            FilterButtonSelectionGrid.BeginAnimation(OpacityProperty, fadeInAnimation);

            //hides the other table that set to the same spot as the selectionPanel spot
            resultTable.Visibility = Visibility.Hidden;
        }
        private void DynamicChooseRobotButton_Click(object sender, RoutedEventArgs e)
        {
            Choose_Robot.Content = ((Button)sender).Content.ToString();
            FilterButtonSelectionGrid.Visibility = Visibility.Hidden; 
        }
    }
}
