using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using OrchestratorAddOn.Pages;

namespace OrchestratorAddOn
{
    public partial class MainWindow : Window
    {
        public static MainPage homePage;
        public static RobotsMonitor robotsMonitorPage;
        public static Logs logsPage;
        public static Overview overviewPage;

        public MainWindow()
        {
            InitializeComponent();

            //initialize all page instances
            homePage = new MainPage();
            robotsMonitorPage = new RobotsMonitor();
            logsPage = new Logs();
            overviewPage=new Overview(); 

            //add the current onclick events to the pages instances 
            homePage.Robots_button_ClickEvent += Robots_button_Click;
            homePage.Logs_button_ClickEvent += Logs_button_Click;
            homePage.Overview_button_ClickEvent += Overview_button_Click;

            //set the initial content to be the home page
            myFrame.Content = homePage;
        }
        //invoked by the main page 
        private void Robots_button_Click(object sender, RoutedEventArgs e)
        {
            myFrame.Content = robotsMonitorPage;
        }
        private void Logs_button_Click(object sender, RoutedEventArgs e)
        {
            myFrame.Content = logsPage;
        }
        private void Overview_button_Click(object sender, RoutedEventArgs e)
        {
            myFrame.Content = overviewPage;
        }

        //makes the drag option possible in every position of the screen
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        
        //the title bar close button
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        //the title bar minimized button
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        //the title bar maximaized button
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;

            else
                WindowState = WindowState.Maximized;
        }

        //navigate back to home page when right mouse button is clicked
        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            myFrame.Content = homePage;
        }
    }
}
