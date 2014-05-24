using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trexis.Finance.Manager
{
    public class Report
    {
        private Dal dal;
        private HashSet<String[]> entries = new HashSet<String[]>();
        private String reporttitle = "";
        private ReportType reporttype;
        private Boolean datefiltered = false;
        private DateTime startdate;
        private DateTime enddate;

        public Report(ReportType reportType)
        {
            try
            {
                this.reporttype = reportType;

                dal = new Dal();

                switch (this.reporttype)
                {
                    case ReportType.IncomeExpenses:
                        this.reporttitle = "Income & Expenses";
                        updateEntries();
                        break;
                    case ReportType.ProductSales:
                        this.reporttitle = "Product Sales";
                        updateEntries();
                        break;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load report " + reportType.ToString(), ex);
            }
        }

        //This is the default
        public void updateEntries()
        {
            this.datefiltered = false;

            HashSet<Hashtable> results;
            switch (this.reporttype)
            {
                case ReportType.IncomeExpenses:
                    results = dal.executeAsHashset("call reportIncomeExpenses(null, null);");
                    populateFromResults(results);
                    break;
                case ReportType.ProductSales:
                    results = dal.executeAsHashset("call reportProductSales(null, null);");
                    populateFromResults(results);
                    break;
            }
        }

        //This is the filtered entries by date
        public void updateEntries(DateTime startDate, DateTime endDate)
        {
            this.datefiltered = true;
            this.startdate = startDate;
            this.enddate = endDate;

            this.entries = new HashSet<String[]>();
            String startdate = startDate.Year + "-" + startDate.Month + "-" + startDate.Day;
            String enddate = endDate.Year + "-" + endDate.Month + "-" + endDate.Day;
            HashSet<Hashtable> results;
            switch (this.reporttype)
            {
                case ReportType.IncomeExpenses:
                    results = dal.executeAsHashset("call reportIncomeExpenses('" + startdate + "', '" + enddate + "');");
                    populateFromResults(results);
                    break;
                case ReportType.ProductSales:
                    results = dal.executeAsHashset("call reportProductSales('" + startdate + "', '" + enddate + "');");
                    populateFromResults(results);
                    break;
            }
        }

        private void populateFromResults(HashSet<Hashtable> results)
        {
            if (results.Count > 0)
            {
                this.entries = new HashSet<String[]>();
                int rowcounter = 0;
                foreach (Hashtable table in results)
                {
                    String[] headerrow = new String[table.Keys.Count];
                    String[] row = new String[table.Keys.Count];
                    int colcounter = 0;
                    foreach (DictionaryEntry pair in table)
                    {
                        if (rowcounter == 0)
                        {
                            headerrow[colcounter] = Utilities.CapitalizeWord(pair.Key.ToString());
                        }

                        if(isDouble(pair.Value.ToString())){
                            row[colcounter] = Utilities.MakeMoneyValue(Convert.ToDouble(pair.Value.ToString()));
                        } else {
                            row[colcounter] = pair.Value.ToString();
                        }
                        colcounter++;
                    }
                    if (rowcounter == 0)
                    {
                        this.entries.Add(headerrow);
                    }
                    this.entries.Add(row);
                    rowcounter++;
                }
            }
        }

        private Boolean isDouble(String value)
        {
            double n;
            return double.TryParse(value, out n);
        }


        public String Title
        {
            get { return this.reporttitle; }
        }

        public HashSet<String[]> Entries
        {
            get { return this.entries; }
        }

        public String HTML
        {
            get
            {
                Hashtable mergefields = new Hashtable();
                DateTime statementdate = DateTime.Now;


                if (this.datefiltered)
                {
                    mergefields.Add("report_period", this.startdate.ToShortDateString() + " - " + this.enddate.ToShortDateString());
                }
                else
                {
                    mergefields.Add("report_period", "");
                }

                HTML html = new HTML("report_" + this.reporttype.ToString(), this.reporttitle + " Report", mergefields);
                html.AddHTML("entries", html.CreateHTMLTableRows(this.entries, true));
                return html.ToString();
            }
        }



    }
}
