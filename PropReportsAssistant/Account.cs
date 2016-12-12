//Account class, manages account frields for building URLs

namespace PropReportsAssistant
{
    public class Account
    {
        //Manages account fields for building URLs

        private static string domain = "!CHANGE ME!";
        private ReportType reportType;
        private string groupId = "-4";
        private string accountId;
        private static string range = "custom";
        
        public Account(string domain, ReportType reportType, string groupId, string accountId)
        {
            Account.domain = domain;
            this.reportType = reportType;
            this.groupId = groupId;
            this.accountId = accountId;
        }

        //Link building methods
        public string HtmlReportLink(string startDate, string endDate)
        {
            //Builds link for visiting html page in a browser
            string link = "https://" + domain +
                "/report.php?reportType=" + reportType.ToString() +
                "&groupId=" + groupId +
                "&accountId=" + accountId +
                "&range=" + range +
                "&startDate=" + startDate +
                "&endDate=" + endDate;
            return link;
        }
        public string HtmlReportLink(Month month)
        {
            return HtmlReportLink(month.Start(), month.End());
        }
        public string ExcelReportLink(string startDate, string endDate)
        {
            //Builds link for downloading an Excel file
            return HtmlReportLink(startDate, endDate) +
                "&mode=1&baseCurrency=USD&export=1";
        }
        public string ExcelReportLink(Month month)
        {
            return ExcelReportLink(month.Start(), month.End());
        }
    }
}
