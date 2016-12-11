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

namespace PropReportsAssistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Add report types to the drop down menu
            foreach (ReportType reportType in Enum.GetValues(typeof(ReportType)))
            {
                reportTypeComboBox.Items.Add(new ReportTypeConverter(reportType));
                reportTypeComboBox.SelectedIndex = (int) ReportType.summaryByDate;
            }
            
        }

        private string getAccountIdFromUrl(string url)
        {
            //Help parse the user's input URL
            string accountIdText = "accountId=";
            int accountIdIndex = url.IndexOf(accountIdText);
            if (accountIdIndex == -1) return "";
            accountIdIndex += accountIdText.Length;
            int endOfAccountId = url.IndexOf('&', accountIdIndex);
            if (endOfAccountId == -1) return "";
            return url.Substring(accountIdIndex, endOfAccountId - accountIdIndex);
        }

        private void generateLinks(object sender, RoutedEventArgs e)
        {
            //Event handler, most of the logic happens on this button press

            //First get the domain and account ID from the input URL
            Uri parseURL;
            try
            {
                parseURL = new Uri(parseUrlTextBox.Text);
            }
            catch (UriFormatException)
            {
                textOutput.Text = "Could not parse input URL. Try copy-pasting again.";
                return;
            }
            string domain = parseURL.Host;
            ReportTypeConverter reportTypeConverter = reportTypeComboBox.SelectedItem as ReportTypeConverter;
            ReportType rt = reportTypeConverter.reportType;
            string accountId = getAccountIdFromUrl(parseUrlTextBox.Text);
            if ((domain.Length <= 0) || (accountId.Length <= 0))
            {
                textOutput.Text = "Could not parse input URL. Try copy-pasting again.";
                return;
            }
            //Now the Account object can be initialized
            Account account = new PropReportsAssistant.Account(domain, rt, accountId);

            //Get the date range and calculate the month boundaries
            DateTime startDate;
            DateTime endDate;
            MonthsList months;
            try
            {
                startDate = startDatePicker.SelectedDate.Value;
                endDate = endDatePicker.SelectedDate.Value;
                months = new MonthsList(startDate, endDate);
            }
            catch (InvalidOperationException)
            {
                textOutput.Text = "Select both dates.";
                return;
            }

            //Output the desired hyperlinks
            bool excel = true;
            if (excelFileRadioButton.IsChecked != null)
            {
                if (excelFileRadioButton.IsChecked == false)
                {
                    excel = false;
                }
            }
            textOutput.Text = "";
            textOutput.Inlines.Clear();
            for (int index = 0; index < months.Count; index++)
            {
                string link;
                if (excel)
                {
                    link = account.ExcelReportLink(months.getMonth(index));
                }
                else
                {
                    link = account.HtmlReportLink(months.getMonth(index));
                }
                try
                {
                    Hyperlink hyperlink = new Hyperlink(new Run(link));
                    hyperlink.NavigateUri = new Uri(link);
                    hyperlink.RequestNavigate += linkClicked;

                    textOutput.Inlines.Add(new Run(months.getMonth(index).WriteFriendlyName()));
                    textOutput.Inlines.Add(new LineBreak());
                    textOutput.Inlines.Add(hyperlink);
                    textOutput.Inlines.Add(new LineBreak());
                }
                catch (UriFormatException)
                {
                    textOutput.Text = "Could not generate valid links.";
                    return;
                }
            }
        }

        private void linkClicked(object sender, RequestNavigateEventArgs e)
        {
            //Event handler for opening a hyperlink in the default browser
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }
    }
}
