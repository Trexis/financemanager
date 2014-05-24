using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trexis.Finance.Manager
{
    public class Customer
    {
        private int id;
        private String name = "";
        private String street = "";
        private String city = "";
        private String zipcode = "";
        private String phone = "";
        private String fax = "";
        private String vatnumber = "";
        private String emailaddress = "";
        private String contact = "";
        private PaymentType paymenttype = PaymentType.COD;
        private User rep;
        private int invoicecount = 0;
        private Double debit = 0;
        private Double credit = 0;

        private Dal dal;

        public Customer()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load customer", ex);
            }
        }


        public Customer(Hashtable userresult)
        {
            try
            {
                populateFromResultTable(userresult);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load customer", ex);
            }
        }

        public Customer(int id)
        {
            try
            {
                dal = new Dal();
                HashSet<Hashtable> results = dal.executeAsHashset("call getCustomerById(" + id + ");");
                populateFromResults(results);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load customer by id " + id, ex);
            }
        }

        public void Save()
        {
            try
            {
                if (this.name.Equals("")) throw new Exception("Name mandatory");

                dal = new Dal();
                HashSet<Hashtable> results = dal.executeAsHashset("call updateCustomer('" + this.name + "', '" + this.street + "', '" + this.city + "', '" + this.zipcode + "', '" + this.phone + "', '" + this.fax + "', '" + this.vatnumber + "', '" + this.emailaddress + "', '" + this.contact + "', " + this.rep.Id + ", " + Convert.ToInt16(this.paymenttype) + ");");
                populateFromResults(results);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to save customer", ex);
            }
        }

        public void Delete()
        {
            try
            {
                dal = new Dal();
                dal.executeNonQuery("call deleteCustomer(" + this.Id + ");");
                this.id = 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to delete Customer", ex);
            }
        }

        private void populateFromResults(HashSet<Hashtable> results)
        {
            if (results.Count > 0)
            {
                foreach (Hashtable table in results)
                {
                    populateFromResultTable(table);
                }
            }
            else
            {
                throw new Exception("No results found");
            }
        }

        private void populateFromResultTable(Hashtable table)
        {
            this.id = Convert.ToInt16(table["id"]);
            this.name = table["name"].ToString();
            this.street = table["street"].ToString();
            this.city = table["city"].ToString();
            this.zipcode = table["zipcode"].ToString();
            this.phone = table["phone"].ToString();
            this.fax = table["fax"].ToString();
            this.vatnumber = table["vatnumber"].ToString();
            this.emailaddress = table["email"].ToString();
            this.contact = table["contact"].ToString();
            this.invoicecount = Convert.ToInt16(table["invoice_count"]);
            this.rep = new User(Convert.ToInt16(table["repid"]));
            this.paymenttype = (PaymentType)Convert.ToInt16(table["paymenttype"]);
            this.debit = table["debit"].ToString().Equals("") ? 0.00 : Convert.ToDouble(table["debit"]);
            this.credit = table["credit"].ToString().Equals("") ? 0.00 : Convert.ToDouble(table["credit"]);
        }

        /*PROPERTIES*/
        public int Id
        {
            get { return this.id; }
        }
        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public String Street
        {
            get { return this.street; }
            set { this.street = value; }
        }
        public String City
        {
            get { return this.city; }
            set { this.city = value; }
        }
        public String Zipcode
        {
            get { return this.zipcode; }
            set { this.zipcode = value; }
        }
        public String VatNumber
        {
            get { return this.vatnumber; }
            set { this.vatnumber = value; }
        }
        public String Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }
        public String Fax
        {
            get { return this.fax; }
            set { this.fax = value; }
        }
        public String EmailAddress
        {
            get { return this.emailaddress; }
            set { this.emailaddress = value; }
        }
        public String Contact
        {
            get { return this.contact; }
            set { this.contact = value; }
        }
        public int InvoiceCount
        {
            get { return this.invoicecount; }
        }
        public User Rep
        {
            get { return this.rep; }
            set { this.rep = value; }
        }
        public PaymentType PaymentType
        {
            get { return this.paymenttype; }
            set { this.paymenttype = value; }
        }

        public Double Balance
        {
            get
            {
                return this.debit - this.credit;
            }
        }

        public Double Debit
        {
            get
            {
                return this.debit;
            }
        }
        public Double Credit
        {
            get
            {
                return this.credit;
            }
        }

    }
}
