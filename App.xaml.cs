using OrchestratorAddOn.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OrchestratorAddOn
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Set up the global exception handler
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // Your other startup code here
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Handle the unhandled exception
            Exception exception = e.ExceptionObject as Exception;

            if (exception != null)
            {
                string filePath = " C:\\Users\\לידור\\source\\repos\\OrchestratorAddOn\\OrchestratorAddOn\\logs\\log1.txt";
                // Open the file for appending (creates the file if it doesn't exist)
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    // Write text to the file
                    writer.WriteLine(exception.Message);

                    // You can add more lines or use other Write/WriteLine methods as needed
                }

                Console.WriteLine("Line has been added to the file successfully.");
            }
        }
    }
}
