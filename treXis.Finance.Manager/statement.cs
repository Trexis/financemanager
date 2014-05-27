using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trexis.Finance.Manager
{
    public class Statement
    {
        private Customer customer;
        private StatementEntry[] entries = new StatementEntry[0];
        private Dal dal;
        private Boolean filtered = false;
        private DateTime startdate;
        private DateTime enddate;
        private DateTime firstentrydate;
        private Boolean zerobased = false;
        private Double openingbalance = 0.00;
        private Double closingbalance = 0.00;

        public Statement(Customer customer, Boolean zeroBased)
        {
            this.customer = customer;
            this.zerobased = zeroBased;
            try
            {
                this.openingbalance = 0;
                this.closingbalance = customer.Balance;
                dal = new Dal();
                HashSet<Hashtable> results = dal.executeAsHashset("call getStatementByCustomerAndDate(" + this.customer.Id + ", null, null);");
                populateFromResults(results);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load statement for customer by id " + this.customer.Id, ex);
            }
        }

        public Statement(Customer customer, Boolean zeroBased, DateTime startdate, DateTime enddate)
        {
            this.customer = customer;
            this.zerobased = zeroBased;
            this.filtered = true;
            this.startdate = startdate;
            this.enddate = enddate;
            this.openingbalance = 0;
            this.closingbalance = customer.Balance;
            try
            {
                String start_datetimestring = startdate.Year + "-" + startdate.Month + "-" + startdate.Day;
                String end_datetimestring = enddate.Year + "-" + enddate.Month + "-" + enddate.Day;
                dal = new Dal();
                HashSet<Hashtable> results = dal.executeAsHashset("call getStatementByCustomerAndDate(" + this.customer.Id + ", '" + start_datetimestring + "', '" + end_datetimestring + "');");
                populateFromResults(results);

                HashSet<Hashtable> openingresults = dal.executeAsHashset("call getCustomerBalanceByDate(" + this.customer.Id + ", '" + start_datetimestring + "');");
                populateOpeningFromResults(openingresults);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load statement for customer by id " + this.customer.Id, ex);
            }
        }

        private void populateOpeningFromResults(HashSet<Hashtable> results)
        {
            if (results.Count > 0)
            {
                int counter = 0;
                foreach (Hashtable table in results)
                {
                    Double debit = table["debit"].ToString().Equals("") ? 0.00 : Convert.ToDouble(table["debit"]);
                    Double credit = table["credit"].ToString().Equals("") ? 0.00 : Convert.ToDouble(table["credit"]);
                    this.openingbalance = debit - credit;
                    counter++;
                }
            }
        }


        private void populateFromResults(HashSet<Hashtable> results)
        {
            if (results.Count > 0)
            {
                this.entries = new StatementEntry[results.Count];
                int counter = 0;
                foreach (Hashtable table in results)
                {
                    StatementEntry entry = new StatementEntry(table);
                    this.entries[counter] = entry;
                    if (counter == 0) firstentrydate = entry.DateTime;
                    counter++;
                }
            }
        }

        public HashSet<String[]> listEntries() {
            Double runningbalance = this.OpeningBalance;
            HashSet<String[]> listentries = new HashSet<String[]>();
            foreach (StatementEntry entry in this.entries)
            {
                runningbalance += entry.Debit - entry.Credit;

                if (this.zerobased && (System.Math.Round(runningbalance, 2) == 0))
                {
                    //reset to empty list if zero based
                    listentries = new HashSet<String[]>();
                }
                else
                {
                    String[] listitem = new String[6];
                    if (entry.EntryType.Equals(EntryType.Invoice))
                    {
                        listitem[0] = entry.Id.ToString();
                    }
                    else
                    {
                        if (entry.Credit > 0)
                        {
                            listitem[0] = "Payment";
                        }
                        else
                        {
                            listitem[0] = "Credit Note";
                        }
                    }
                    listitem[1] = entry.DateTime.ToShortDateString();
                    listitem[2] = Utilities.MakeMoneyValue(entry.Debit);
                    listitem[3] = Utilities.MakeMoneyValue(entry.Credit);
                    listitem[4] = Utilities.MakeMoneyValue(runningbalance);
                    listitem[5] = entry.EntryType.Equals(EntryType.Payment) ? entry.Id.ToString() : "";
                        
                    listentries.Add(listitem);
                }
            }

            return listentries; 
        }

        public StatementEntry[] Entries{
            get { return this.entries; }
        }

        public Double OpeningBalance
        {
            get { return this.openingbalance; }
        }

        public Double ClosingBalance
        {
            get { return this.closingbalance; }
        }

        public Customer Customer
        {
            get { return this.customer; }
        }

        public String HTML
        {
            get
            {
                return getHTML("statement", "");
            }
        }
        public String EmailHTML
        {
            get
            {
                return getHTML("statement", "http://www.meulenfoods.co.za/email_design/");
            }
        }

        private String getHTML(String templatename, String templatelocation)
        {
            Hashtable mergefields = new Hashtable();
            mergefields.Add("customer_name", this.customer.Name);
            mergefields.Add("customer_street", this.customer.Street);
            mergefields.Add("customer_city", this.customer.City);
            mergefields.Add("customer_zip", this.customer.Zipcode);
            mergefields.Add("customer_vat", this.customer.VatNumber);
            mergefields.Add("customer_phone", this.customer.Phone);
            mergefields.Add("customer_fax", this.customer.Fax);
            mergefields.Add("customer_email", this.customer.EmailAddress);
            mergefields.Add("customer_contact", this.customer.Contact);
            mergefields.Add("customer_rep", this.customer.Rep.FriendlyName);

            DateTime statementdate = DateTime.Now;
            mergefields.Add("statement_date", statementdate.ToShortDateString());
            mergefields.Add("statement_openingbalance", Utilities.MakeMoneyValue(this.openingbalance));
            mergefields.Add("statement_closingbalance", Utilities.MakeMoneyValue(this.closingbalance));
            if (this.filtered)
            {
                mergefields.Add("statement_period", this.startdate.ToShortDateString() + " - " + this.enddate.ToShortDateString());
            }
            else
            {
                mergefields.Add("statement_period", this.firstentrydate.ToShortDateString() + " - " + statementdate.ToShortDateString());
            }

            if (!templatelocation.Equals(""))
            {
                mergefields.Add("templatelocation", templatelocation);
            }

            HTML html = new HTML(templatename, "Statement " + this.customer.Name, mergefields);
            html.AddHTML("entries", html.CreateHTMLTableRows(this.listEntries(), false));
            return html.ToString();
        }



    }
}
