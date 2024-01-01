using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using LiveCharts.Wpf;
using LiveCharts;
using OrchestratorAddOn.Queries;
using Org.BouncyCastle.Utilities;
using LiveCharts.Definitions.Charts;
using LiveCharts.Defaults;
using Org.BouncyCastle.Asn1.X500;
using LiveCharts.Definitions.Series;
using OrchestratorAddOn.Classes;

namespace OrchestratorAddOn.Pages
{
    public partial class Overview : Page
    {
        private DispatcherTimer _timer;
        private SeriesCollection pieSeriesCollection;
      
        public Overview()
        {
            InitializeComponent();
            GetDataFromDatabase();
          
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(60); // set your refresh interval
            _timer.Tick += Timer_Tick;
            _timer.Start();        
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Refresh data from the database and update the ViewModel
            try
            {
                GetDataFromDatabase();
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, display a message, etc.)
                MessageBox.Show($"Error updating PieSeries{ex.Message}");
            }
        }
        public void SetCharts(List<JobsData> jobsData)
        {
            if(jobsData.Count==0)
            {
                pieChartRunningJobs.Visibility = Visibility.Collapsed;
                return;
            }
            pieSeriesCollection = new SeriesCollection();
            foreach (var jobData in jobsData)
            {
                pieSeriesCollection.Add(new PieSeries
                {
                    Title = jobData.Robots,
                    Values = new ChartValues<double> { 100 / jobsData.Count },
                    DataLabels = true,
                    LabelPoint = point => jobData.ProcessName,
                }) ;
            }
            pieChartRunningJobs.Series = pieSeriesCollection;
        }
        public void setStringsToChart(List<string> data)
        {
            if (data.Count == 0)
            {
                pieChartPendingTransactions.Visibility = Visibility.Collapsed;
                return;
            }
            pieSeriesCollection = new SeriesCollection();
            foreach (var val in data)
            {
                pieSeriesCollection.Add(new PieSeries
                {
                    Title = val,
                    Values = new ChartValues<double> { 100 / data.Count },
                    DataLabels = true
                    //LabelPoint = point => jobData.ProcessName,
                });
            }
            pieChartPendingTransactions.Series = pieSeriesCollection;
        }
        public void GetDataFromDatabase()
        {
            runningJobsLabel.Content = DatabaseAccess.GetRunningJobs();
            SetCharts(DatabaseAccess.GetRunningJobsDetails());

            pendingTransactionsLabel.Content= DatabaseAccess.GetPendingTransactions();
            setStringsToChart(DatabaseAccess.GetPendingTransactionsDetails());

            successfulTransactionsLabel.Content = DatabaseAccess.GetSuccessfulTransactions();
            faildTransactionsLabel.Content=DatabaseAccess.GetFailedTransactions();

            SetForeground();
        }

        public void SetForeground()
        {
            if(int.Parse(runningJobsLabel.Content.ToString())>0)
                runningJobsLabel.Foreground = Brushes.LightBlue;
            if (int.Parse(runningJobsLabel.Content.ToString()) == 0)
                runningJobsLabel.Foreground = Brushes.Black;
            if (int.Parse(runningJobsLabel.Content.ToString()) == 0 && (int.Parse(pendingTransactionsLabel.Content.ToString())>0))
                runningJobsLabel.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7C0A02"));

            if (int.Parse(pendingTransactionsLabel.Content.ToString()) <200)
                pendingTransactionsLabel.Foreground = Brushes.LightBlue;
            else
                pendingTransactionsLabel.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7C0A02"));

            if (int.Parse(successfulTransactionsLabel.Content.ToString()) > 0)
                successfulTransactionsLabel.Foreground = Brushes.LightBlue;

            if (int.Parse(faildTransactionsLabel.Content.ToString()) > int.Parse(successfulTransactionsLabel.Content.ToString()))
                faildTransactionsLabel.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7C0A02"));
            else
                faildTransactionsLabel.Foreground = Brushes.LightBlue;
        }

    }
}
