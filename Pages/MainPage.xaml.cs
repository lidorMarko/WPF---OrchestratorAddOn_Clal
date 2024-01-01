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

namespace OrchestratorAddOn.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //Navigation methods
        public delegate void onRobots_button_Click(object sender, RoutedEventArgs e);
        public event onRobots_button_Click Robots_button_ClickEvent;

        public delegate void onLogs_button_Click(object sender, RoutedEventArgs e);
        public event onLogs_button_Click Logs_button_ClickEvent;

        public delegate void onOverview_button_Click(object sender, RoutedEventArgs e);
        public event onLogs_button_Click Overview_button_ClickEvent;

        private void Robots_button_Click(object sender, RoutedEventArgs e)
        {
            Robots_button_ClickEvent(sender, e);
        }
        private void Logs_buttom_Click(object sender, RoutedEventArgs e)
        {
            Logs_button_ClickEvent(sender, e);
        }
        private void Overview_button_Click(object sender, RoutedEventArgs e)
        {
            Overview_button_ClickEvent(sender, e);
        }
        private void Operations_button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Reports_button_Click(object sender, RoutedEventArgs e)
        {

        }

        //hover on one of the home page buttons
        private Brush originalBackground; // Store the original button background
        private void Logs_buttom_MouseEnter(object sender, RoutedEventArgs e)
        {
            originalBackground = Logs_buttom.Background;
            Logs_buttom.Background = Brushes.Black;
            Logs_buttom_text.Visibility = Visibility.Visible;
        }
        private void Logs_buttom_MouseLeave(object sender, MouseEventArgs e)
        {
            Logs_buttom.Background = originalBackground.Clone(); // Restore the original background
            Logs_buttom_text.Visibility = Visibility.Hidden;
        }
        private void Robots_button_MouseEnter(object sender, MouseEventArgs e)
        {
            originalBackground = Robots_button.Background;
            Robots_button.Background = Brushes.Black;
            Robots_button_text.Visibility = Visibility.Visible;
        }
        private void Robots_button_MouseLeave(object sender, MouseEventArgs e)
        {
            Robots_button.Background = originalBackground.Clone(); // Restore the original background
            Robots_button_text.Visibility = Visibility.Hidden;
        }
        private void Overview_button_MouseEnter(object sender, MouseEventArgs e)
        {
            originalBackground = Overview_button.Background;
            Overview_button.Background = Brushes.Black;
            Overview_button_text.Visibility = Visibility.Visible;
        }
        private void Overview_button_MouseLeave(object sender, MouseEventArgs e)
        {
            Overview_button.Background = originalBackground.Clone(); // Restore the original background
            Overview_button_text.Visibility = Visibility.Hidden;
        }
        private void Operations_button_MouseEnter(object sender, MouseEventArgs e)
        {
            originalBackground = Operations_button.Background;
            Operations_button.Background = Brushes.Black;
            Operations_button_text.Visibility = Visibility.Visible;
        }
        private void Operations_button_MouseLeave(object sender, MouseEventArgs e)
        {
            Operations_button.Background = originalBackground.Clone(); // Restore the original background
            Operations_button_text.Visibility = Visibility.Hidden;
        }
        private void Reports_button_MouseEnter(object sender, MouseEventArgs e)
        {
            originalBackground = Reports_button.Background;
            Reports_button.Background = Brushes.Black;
            Reports_button_text.Visibility = Visibility.Visible;
        }
        private void Reports_button_MouseLeave(object sender, MouseEventArgs e)
        {
            Reports_button.Background = originalBackground.Clone(); // Restore the original background
            Reports_button_text.Visibility = Visibility.Hidden;
        }
    }
}
