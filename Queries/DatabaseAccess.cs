using MySql.Data.MySqlClient;
using OrchestratorAddOn.Classes;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OrchestratorAddOn.Queries
{
    public class DatabaseAccess
    {
        public static List<JobsData> GetRunningJobsDetails()
        {
            List<JobsData> output = new List<JobsData>();

            string[] lines = File.ReadAllLines("C:\\Users\\לידור\\source\\repos\\OrchestratorAddOn\\OrchestratorAddOn\\dummyDb\\1_details.txt");
            foreach (string line in lines)
            {
                //the sql queries will deal with the aggregation and the regex will be no longer needed
                output.Add(new JobsData(line.Split("-")[1], line.Split("-")[0]));
            }
            return output;
        }

        public static List<string> GetPendingTransactionsDetails()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\לידור\\source\\repos\\OrchestratorAddOn\\OrchestratorAddOn\\dummyDb\\1_details.txt");
            return lines.ToList();
        }

        public static string GetRunningJobs()
        {
            // Use StreamReader to read the text from the file
            using (StreamReader reader = new StreamReader("C:\\Users\\לידור\\source\\repos\\OrchestratorAddOn\\OrchestratorAddOn\\dummyDb\\1.txt"))
            {
                // Read the entire content of the file
                string fileContent = reader.ReadToEnd();

                // Display the content in a TextBox or any other control
                return fileContent;
            }
        }
        public static string GetPendingTransactions()
        {
            // Use StreamReader to read the text from the file
            using (StreamReader reader = new StreamReader("C:\\Users\\לידור\\source\\repos\\OrchestratorAddOn\\OrchestratorAddOn\\dummyDb\\2.txt"))
            {
                // Read the entire content of the file
                string fileContent = reader.ReadToEnd();

                // Display the content in a TextBox or any other control
                return fileContent;
            }
        }
        public static string GetSuccessfulTransactions()
        {
            // Use StreamReader to read the text from the file
            using (StreamReader reader = new StreamReader("C:\\Users\\לידור\\source\\repos\\OrchestratorAddOn\\OrchestratorAddOn\\dummyDb\\3.txt"))
            {
                // Read the entire content of the file
                string fileContent = reader.ReadToEnd();

                // Display the content in a TextBox or any other control
                return fileContent;
            }
        }
        public static string GetFailedTransactions()
        {
            // Use StreamReader to read the text from the file
            using (StreamReader reader = new StreamReader("C:\\Users\\לידור\\source\\repos\\OrchestratorAddOn\\OrchestratorAddOn\\dummyDb\\4.txt"))
            {
                // Read the entire content of the file
                string fileContent = reader.ReadToEnd();

                // Display the content in a TextBox or any other control
                return fileContent;
            }
        }

        //This method return the all relavent transaction with their whole data
        // the data of each transaction will be 
        // reference
        // robot
        // start time 
        // end time 
        // process name
        // LOGS!!
        public static TransactionData[] RetrieveTransactionDataFromDatabase()
        { 
            //string connectionString = "server=(localdb)\\localDummyDb;database=master;user id=DESKTOP-K42BBLO\\לידור;password=1804";
            //using (MySqlConnection connection = new MySqlConnection(connectionString))
            //{
            //    MessageBox.Show("aaa");
            //    connection.Open();
            //    MessageBox.Show("bbb");
            //    string query = "SELECT * FROM your_table_name";
            //    MySqlCommand command = new MySqlCommand(query, connection);

            //    using (MySqlDataReader reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            // Assuming your data is stored in a column named "your_column_name"
            //            string value = reader["your_column_name"].ToString();
            //            //data.Add(value);
            //        }
            //    }
            //}



            TransactionData[] results = new TransactionData[3];
            //Dummy data
            TransactionLogs[] l1 = new TransactionLogs[]
                            { new TransactionLogs("12/1/2023 10:00", "Info", "התחלת בדיקות"),
                            new TransactionLogs("12/1/2023 10:01", "Info", "שלום"),
                            new TransactionLogs("12/1/2023 10:02", "Trace", "נלחץ תביעות"),
                            new TransactionLogs("12/1/2023 10:02", "Trace", "נלחץ 1"),
                            new TransactionLogs("12/1/2023 10:02", "Trace", "נלחץ 2"),
                            new TransactionLogs("12/1/2023 10:02", "Trace", "נלחץ 3"),
                            new TransactionLogs("12/1/2023 10:02", "Trace", "נלחץ 4"),
                            new TransactionLogs("12/1/2023 10:02", "Trace", "נלחץ 5"),
                            new TransactionLogs("12/1/2023 10:02", "Trace", "נלחץ 6"),
                            new TransactionLogs("12/1/2023 10:02", "Trace", "נלחץ 7"),
                            new TransactionLogs("12/1/2023 10:02", "Trace", "נלחץ 8"),
                            new TransactionLogs("12/1/2023 10:02", "Trace", "נלחץ 9"),
                            new TransactionLogs("12/1/2023 10:02", "Trace", "נלחץ 10"),
                            new TransactionLogs("12/1/2023 10:02", "Trace", "נלחץ 11"),
                            new TransactionLogs("12/1/2023 10:02", "Trace", "נלחץ 12"),
                            new TransactionLogs("12/1/2023 10:02", "Trace", "נלחץ 13")};
    TransactionLogs[] l2 = new TransactionLogs[]
                            { new TransactionLogs("10/12/2023 10:10", "Info", "לידור"),
                            new TransactionLogs("10/12/2023 10:11", "Trace", "markovich"),
                            new TransactionLogs("10/12/2023 10:12", "Trace", "שלטם")};
            TransactionLogs[] l3 = new TransactionLogs[]
                            { new TransactionLogs("12/1/2023 10:00", "Trace", "טקרנזקציה שלישית"),
                            new TransactionLogs("12/1/2023 10:01", "Info", "שלום"),
                            new TransactionLogs("12/1/2023 10:02", "Fatal", "נלחץ טרט קטר רט רט רררט ראט רט 6 א יט יראכי ט רררט ראט רט 6 א יט יראכי רט רררט ראט רט 6 א יט יראכי רט רררט ראט רט 6 א יט יראכי רט רררט ראט רט 6 א יט יראכי ררטאלידור")};


            results[0] = new TransactionData("Robotuipp01", "process1", "12:55", "13:38", "1234", l1);
            results[1] = new TransactionData("Robotuipp02", "process2", "19:00", "19:01", "11123", l2);
            results[2] = new TransactionData("Robotuipp03", "process1", "12:00", "13:00", "00f0000", l3);

          
            return results;
        }

        //This method returns all exists paths
        public static string[] RetriveAllPaths()
        {
            return new string[]{"Root","Root/Gemel","Root/Life"};
        }
        //This method returns all posible filters 
        public static string[] RetriveAllPossibleFilters()
        {
            return new string[] { "Reference Starts With", "Reference Ends With", "Analytics Contains",
                                  "Specific Content Contains"};
        }
        public static string GetSchemaByFilterSelection(string filter)
        {
            switch (filter)
            {
                case "ReferenceStartsWith":
                    return "Reference";
                case "ReferenceEndsWith":
                    return "Reference";
                case "AnalyticsContains":
                    return "key:value";
                case "SpecificContentContains":
                    return "key:value";
                default: return "";

            }     
        }
        public static string[] RetriveAllRobotNames()
        {
            return new string[] { "Robotuipp01","Robotuipp02","Robotuipp03"};
        }
        //public static RobotMonitorDataRow[] GetRobotSchedule(string robotName,string date)
        //{
        //    Task.Delay(90000);
        //    return new RobotMonitorDataRow[] {new ("Robotuipp01", "07:00", "07:04", "Risk"),
        //                                      new ("Robotuipp01", "07:04", "07:08", ""),
        //                                      new ("Robotuipp01", "07:08", "08:08", "InvestingRouteChange")};

        //}
        public static async Task<RobotMonitorDataRow[]> GetRobotSchedule(string robotName, string date)
        {
            await Task.Delay(2000);
            return new RobotMonitorDataRow[] {new ("Robotuipp01", "07:00", "07:04", "Risk"),
                                              new ("Robotuipp01", "07:04", "07:08", ""),
                                              new ("Robotuipp01", "07:08", "08:08", "InvestingRouteChange")};

        }

    }
}
