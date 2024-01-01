using OrchestratorAddOn.Classes;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OrchestratorAddOn.Queries;
using System.Data;

namespace OrchestratorAddOn.Pages
{
    /// <summary>
    /// Interaction logic for Logs.xaml
    /// </summary>
    public partial class Logs : Page
    {
        private LogsFilterSelection choosenFilter;
        private string defaultText="Reference";
        private TransactionData[] resultTransactions;

        private static string defaultSearchBarTextBoxContent="log message";

        public Logs()
        {
            InitializeComponent();

        }

        //habdle the textbox default text functionality
        private void TextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (searchRowTextBox.Text.Equals(defaultText))
                searchRowTextBox.Text = "";
        }
        private void SearchRowTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (searchRowTextBox.Text.Equals(""))
                searchRowTextBox.Text = defaultText;
        }
        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            if (searchRowTextBox.Text.Equals(defaultText))
                return;

            //create a logFilterSelection object
            choosenFilter = new LogsFilterSelection(pathSelection.Content.ToString(), 
                            (FilterOptions)Enum.Parse(typeof(FilterOptions), filterOption.Content.ToString().Replace(" ","")),
                            searchRowTextBox.Text);

            //retriev the transactions data that fits the new selection
            resultTransactions=DatabaseAccess.RetrieveTransactionDataFromDatabase();

            //add the retrieved transactions to the data grid 
            // the grid will display the basic data about the transactions 
            // and when a specific transaction will be selected -
            // its whole data will be displyed in another panel
            for (int i = 0; i < resultTransactions.Length; i++)
            {
                resultTable.Items.Add(resultTransactions[i]);
            }

            //Adjust table's max height
            GlobalMethods.AdjustDataGridMaxHeight(resultTable);

            //make the table visible
            resultTable.Visibility = Visibility.Visible;
            //hides the other two tables that set to the same spot as the path selection spot
            FilterButtonSelectionGrid.Visibility=Visibility.Hidden;
            ChoosenTransactionlogsPanel.Visibility = Visibility.Hidden;
        }

        private void ResultTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //hide the result table
            resultTable.Visibility = Visibility.Collapsed;
            //show the transaction logs header
            ChoosenTransactionlogsPanel.Visibility = Visibility.Visible;
            ChoosenTransactionlogsHeader.Visibility = Visibility.Visible;
            //hides the other panel that set to the same spot
            FilterButtonSelectionGrid.Visibility = Visibility.Hidden;

            TransactionData choosenTransaction= (TransactionData)(resultTable.SelectedItem);

            //add the transaction reference to the ChoosenTransactionReference label
            ChoosenTransactionReference.Content= "Transaction "+ choosenTransaction.reference;
            //add the data of the choosen transaction to the log table so it will be displayed
            for (int i = 0; i < choosenTransaction.logs.Length; i++)
            {
                ChoosenTransactionlogsTable.Items.Add(choosenTransaction.logs[i]);
            }

            //Adjust table's max height
            GlobalMethods.AdjustDataGridMaxHeight(ChoosenTransactionlogsTable);
        }

        private void BtnCloseTransactionLogs_Click(object sender, RoutedEventArgs e)
        {
            //show the result table
            resultTable.Visibility = Visibility.Visible;
            //hide the transaction logs header
            ChoosenTransactionlogsHeader.Visibility = Visibility.Hidden;
            //clear the transctionlogs table
            ChoosenTransactionlogsTable.Items.Clear();
            //clear the searching bar text
            SearchBarTextBox.Text = defaultSearchBarTextBoxContent;
        }

        private void PathSelection_Click(object sender, RoutedEventArgs e)
        {
            string[] allPaths = DatabaseAccess.RetriveAllPaths();
            ButtonsWrapPanel.Children.Clear();
            for (int i = 0; i < allPaths.Length; i++)
            {
                Button button = new Button();
                button.Content=allPaths[i];
                button.Click += DynamicPathButton_Click;
                button.Style = (Style)FindResource("selectionButtons");

                //add the new button to the stackpanel
                ButtonsWrapPanel.Children.Add(button);
            }
            //set the buttons panel visibility and animate the entrance
            FilterButtonSelectionGrid.Visibility = Visibility.Visible;
            DoubleAnimation fadeInAnimation = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(1.5)));
            FilterButtonSelectionGrid.BeginAnimation(OpacityProperty, fadeInAnimation);

            //hides the other two tables that set to the same spot as the path selection spot
            resultTable.Visibility = Visibility.Hidden;
            ChoosenTransactionlogsPanel.Visibility = Visibility.Hidden;
        }
        //This method handles a case inwhich one of the path buttons is clicked
        private void DynamicPathButton_Click(object sender, RoutedEventArgs e)
        {
            pathSelection.Content= ((Button)sender).Content.ToString();
            FilterButtonSelectionGrid.Visibility = Visibility.Hidden;
        }

        private void FilterOption_Click(object sender, RoutedEventArgs e)
        {
            string[] allFilterOptions = DatabaseAccess.RetriveAllPossibleFilters();
            ButtonsWrapPanel.Children.Clear();
            for (int i = 0; i < allFilterOptions.Length; i++)
            {
                Button button = new Button();
                button.Content = allFilterOptions[i];
                button.Click += DynamicFilterOptionButton_Click;
                button.Style = (Style)FindResource("selectionButtons");

                //add the new button to the stackpanel
                ButtonsWrapPanel.Children.Add(button);
            }
            //set the buttons panel visibility and animate the entrance
            FilterButtonSelectionGrid.Visibility = Visibility.Visible;
            DoubleAnimation fadeInAnimation = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(1.5)));
            FilterButtonSelectionGrid.BeginAnimation(OpacityProperty, fadeInAnimation);

            //hides the other two tables that set to the same spot as the path selection spot
            resultTable.Visibility = Visibility.Hidden;
            ChoosenTransactionlogsPanel.Visibility = Visibility.Hidden;
        }
        private void DynamicFilterOptionButton_Click(object sender, RoutedEventArgs e)
        {
            filterOption.Content = ((Button)sender).Content.ToString();
            FilterButtonSelectionGrid.Visibility = Visibility.Hidden;

            //when changed - set the deault text acordingly
            defaultText = DatabaseAccess.GetSchemaByFilterSelection(filterOption.Content.ToString().Replace(" ",""));
            searchRowTextBox.Text= defaultText;
        }

        private void Close_buttonsPanel_Click(object sender, RoutedEventArgs e)
        {
            FilterButtonSelectionGrid.Visibility = Visibility.Hidden;
        }

        //habdle the searfch for log textbox default text functionality
        private void SearchBarTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SearchBarTextBox.Text.Equals(defaultSearchBarTextBoxContent))
                SearchBarTextBox.Text = "";
        }
        private void SearchBarTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBarTextBox.Text.Equals(""))
                SearchBarTextBox.Text = defaultSearchBarTextBoxContent;
        }

        private void SearchBarButton_Click(object sender, RoutedEventArgs e)
        {
            string textToSearch = SearchBarTextBox.Text.ToLower();
            foreach(var item in ChoosenTransactionlogsTable.Items)
            {
                var cellText=((TransactionLogs)item).message.ToLower();
                if (cellText.Contains(textToSearch))
                {
                    ChoosenTransactionlogsTable.SelectedItem = item;
                    ChoosenTransactionlogsTable.ScrollIntoView(item);
                }
            }
        }
    }
}