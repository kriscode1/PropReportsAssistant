//Defines the ReportType enum and class to convert the enum to strings

namespace PropReportsAssistant
{
    public enum ReportType
    {
        detailed, trades, performance, performanceForGroup, performanceByAccount,
        totalsByDate, summaryByDate, totalsByAccount, totalsByGroup, totalsBySymbol,
        totalsBySymbolForGroup, destination, destinationForGroup, openPositions,
        openPositionsForGroup, openPositionsSummary, openPositionsSummaryForGroup,
        expiringOptionsForGroup, adjustment, adjustmentForGroup, export
    };

    class ReportTypeConverter
    {
        //Class for converting the ReportType enum to a nice string

        public ReportType reportType { get; }
        public ReportTypeConverter(ReportType reportType)
        {
            this.reportType = reportType;
        }
        public override string ToString()
        {
            switch (reportType)
            {
                case ReportType.detailed:
                    return "Detailed";
                case ReportType.trades:
                    return "Trades";
                case ReportType.performance:
                    return "Trade Performance";
                case ReportType.performanceForGroup:
                    return "Group Trade Performance";
                case ReportType.performanceByAccount:
                    return "Trade Performance by Account";
                case ReportType.totalsByDate:
                    return "Totals By Date";
                case ReportType.summaryByDate:
                    return "Summary By Date";
                case ReportType.totalsByAccount:
                    return "Totals By Account";
                case ReportType.totalsByGroup:
                    return "Totals By Group";
                case ReportType.totalsBySymbol:
                    return "Totals By Symbol";
                case ReportType.totalsBySymbolForGroup:
                    return "Group Totals By Symbol";
                case ReportType.destination:
                    return "Fees by Destination";
                case ReportType.destinationForGroup:
                    return "Group Fees by Destination";
                case ReportType.openPositions:
                    return "Open Positions";
                case ReportType.openPositionsForGroup:
                    return "Group Open Positions";
                case ReportType.openPositionsSummary:
                    return "Open Positions Summary";
                case ReportType.openPositionsSummaryForGroup:
                    return "Group Open Positions Summary";
                case ReportType.expiringOptionsForGroup:
                    return "Expiring Options for Group";
                case ReportType.adjustment:
                    return "Adjustments";
                case ReportType.adjustmentForGroup:
                    return "Group Adjustments";
                case ReportType.export:
                    return "Export Fills to Excel";
                default:
                    return "";
            }
        }
    }
}
