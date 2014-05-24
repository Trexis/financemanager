using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trexis.Finance.Manager
{
    public class Payment
    {
        private Customer customer;
        private Invoice invoice = null;
        private DateTime datetime;
        private Dal dal;

        public Payment(Customer Customer)
        {
            this.customer = Customer;
        }
        public Payment(Invoice Invoice)
        {
            this.invoice = Invoice;
            this.customer = invoice.Customer;
        }

        public void Pay(Double amount, DateTime date)
        {
            try
            {
                if (amount==0) throw new Exception("Amount mandatory");

                this.datetime = date;
                String datetimestring = this.Date.Year + "-" + this.Date.Month + "-" + this.Date.Day;

                dal = new Dal();
                if (invoice != null)
                {
                    dal.executeNonQuery("call addPayment(" + this.customer.Id + ", " + amount + ", " + this.invoice.Id + ", '" + datetimestring + "');");
                }
                else
                {
                    dal.executeNonQuery("call addPayment(" + this.customer.Id + ", " + amount + ", 0, '" + datetimestring + "');");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to make payment", ex);
            }

        }

        public DateTime Date
        {
            get { return this.datetime; }
            set { this.datetime = value; }
        }

    }
}
