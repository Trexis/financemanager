using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trexis.Finance.Manager
{
    public class StatementEntry
    {
        private int id = 0;
        private DateTime datetime;
        private EntryType entrytype = EntryType.Invoice;
        private Double debit = 0.00;
        private Double credit = 0.00;

        public StatementEntry(Hashtable entryresult)
        {
            try
            {
                populateFromResultTable(entryresult);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load statement entry", ex);
            }
        }

        private void populateFromResultTable(Hashtable table)
        {
            this.id = Convert.ToInt16(table["id"]);
            this.entrytype = (EntryType)Convert.ToInt16(table["type"]);
            this.datetime = DateTime.Parse(table["datetime"].ToString());
            this.debit = table["debit"].ToString().Equals("") ? 0.00 : Convert.ToDouble(table["debit"]);
            this.credit = table["credit"].ToString().Equals("") ? 0.00 : Convert.ToDouble(table["credit"]);
        }

        public int Id
        { 
            get { return this.id; }
        }
        public EntryType EntryType
        {
            get { return this.entrytype; }
        }
        public DateTime DateTime
        {
            get { return this.datetime; }
        }
        public Double SubTotal
        {
            get { return this.debit - this.credit; }
        }
        public Double Debit
        {
            get { return this.debit; }
        }
        public Double Credit
        {
            get { return this.credit; }
        }
    }
}
