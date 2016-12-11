using System;

namespace PropReportsAssistant
{
    public class Month
    {
        //Keeps track of the start and end of a month
        private DateTime startDate;
        private DateTime endDate;

        public Month(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }
        public override string ToString()
        {
            return "(" + startDate.ToStringCustom() + "," +
                               endDate.ToStringCustom() + ")";
        }
        public string Start()
        {
            return startDate.ToStringCustom();
        }
        public string End()
        {
            return endDate.ToStringCustom();
        }
        public string WriteFriendlyName()
        {
            //String format like: "January 2016", "February 2017"
            return startDate.ToString("y");
        }
    }
}
