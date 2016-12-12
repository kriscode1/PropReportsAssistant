using System;
using System.Collections.Generic;

namespace PropReportsAssistant
{
    public class MonthsList
    {
        //Keeps track of the months between startDate and endDate
        //When using this class, access: Count, GetMonth(n)

        private DateTime startDate;
        private DateTime endDate;
        private int count = 0;
        private List<Month> months = new List<Month>();

        public int Count
        {
            //Count of months, readonly
            get { return count; }
        }
        public Month GetMonth(int n)
        {
            //Prevents users of MonthsList from modifying the list
            return months[n];
        }
        private static bool SameMonthYear(DateTime date1, DateTime date2)
        {
            if ((date1.Year == date2.Year) &&
                (date1.Month == date2.Month)) return true;
            return false;
        }
        public MonthsList(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            if (SameMonthYear(startDate, endDate))
            {
                //Only 1 month
                months.Add(new Month(startDate, endDate));
                this.count = 1;
            }
            else
            {
                //Multiple monthss
                //First add this months
                int lastDay = DateTime.DaysInMonth(startDate.Year, startDate.Month);
                DateTime endOfMonth = new DateTime(startDate.Year, startDate.Month, lastDay);
                months.Add(new Month(startDate, endOfMonth));
                count = 1;

                //Now add all the monthss until the last months
                DateTime workingMonthStart = new DateTime(startDate.Year, startDate.Month, 1);
                workingMonthStart = workingMonthStart.AddMonths(1);
                while (!SameMonthYear(workingMonthStart, endDate))
                {
                    lastDay = DateTime.DaysInMonth(workingMonthStart.Year, workingMonthStart.Month);
                    endOfMonth = new DateTime(workingMonthStart.Year,
                                              workingMonthStart.Month,
                                              lastDay);
                    months.Add(new Month(workingMonthStart, endOfMonth));
                    count++;
                    workingMonthStart = workingMonthStart.AddMonths(1);
                }

                //Finally add the last months
                months.Add(new Month(workingMonthStart, endDate));
                count++;
            }
        }
        public override string ToString()
        {
            string ret = "";
            for (int n = 0; n < count; n++)
            {
                ret += months[n].ToString() + "\n";
            }
            return ret;
        }
    }
}
