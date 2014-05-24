using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trexis.Finance.Manager
{
    public class Invoice
    {
        private int id = 0;
        private Customer customer;
        private DateTime datetime;
        private InvoiceProduct[] products = new InvoiceProduct[0];
        private String instructions = "";
        private String createdby = "";
        private Double debit = 0.00;
        private Double credit = 0.00;
        private Boolean finalized = false;
        private PaymentType paymentdue = PaymentType.COD;
        private Dal dal;
        private double subtotal = 0;
        private double vat = 0;


        //for performance improvement
        private int customerid = 0;
        private String customername = "";
        private String repname = "";
        private Boolean customerloaded = false;

        public Invoice()
        {
            try
            {
                customer = new Customer();
                datetime = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load invoice", ex);
            }
        }


        public Invoice(Hashtable result)
        {
            try
            {
                populateFromResultTable(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load invoice", ex);
            }
        }

        public Invoice(int id)
        {
            try
            {
                dal = new Dal();
                HashSet<Hashtable> results = dal.executeAsHashset("call getInvoiceById(" + id + ");");
                populateFromResults(results);
                HashSet<Hashtable> productsresults = dal.executeAsHashset("call getInvoiceProductsById(" + id + ");");
                populateProductsFromResults(productsresults);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load invoice by id " + id, ex);
            }
        }

        public void Save()
        {
            try
            {
                String datetimestring = this.Date.Year + "-" + this.Date.Month + "-" + this.Date.Day;
                dal = new Dal();
                if (this.id == 0)
                {
                    HashSet<Hashtable> results = dal.executeAsHashset("call updateInvoice(null, " + this.customerid + ",'" + datetimestring  + "','" + this.createdby + "','" + this.instructions + "', " + Convert.ToInt16(this.finalized) + ", " + Convert.ToInt16(this.paymentdue) + ");");
                    populateFromResults(results);
                }
                else
                {
                    HashSet<Hashtable> results = dal.executeAsHashset("call updateInvoice(" + this.id + ", " + this.customerid + ",\"" + datetimestring + "\",\"" + this.createdby + "\",\"" + this.instructions + "\", " + Convert.ToInt16(this.finalized) + "," + Convert.ToInt16(this.paymentdue) + ");");
                    populateFromResults(results);
                    dal.executeNonQuery("call deleteInvoiceProducts(" + this.id + ");");
                }

                foreach (InvoiceProduct product in this.products)
                {
                    dal.executeNonQuery("call addInvoiceProduct(" + this.id + ", '" + product.Name + "', " + product.Price + ", " + product.Quantity + ", " + Convert.ToInt16(product.HasVat) + ");");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Unable to save invoice", ex);
            }
        }

        public void Delete()
        {
            try
            {
                dal = new Dal();
                dal.executeNonQuery("call deleteInvoice(" + this.Id + ");");
                this.id = 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to delete invoice", ex);
            }
        }

        private void populateProductsFromResults(HashSet<Hashtable> results)
        {
            if (results.Count > 0)
            {
                this.products = new InvoiceProduct[results.Count];
                int counter = 0;
                foreach (Hashtable table in results)
                {
                    products[counter] = new InvoiceProduct(table);
                    counter++;
                }
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
            this.customerid = Convert.ToInt16(table["customer_id"]);
            this.customername = table["customer_name"].ToString();
            this.repname = table["repname"].ToString();
            this.createdby = table["createdby"].ToString();
            this.paymentdue = (PaymentType)Convert.ToInt16(table["paymentdue"].ToString());
            this.datetime = DateTime.Parse(table["datetime"].ToString());
            this.instructions = table["instructions"].ToString();
            this.finalized = Boolean.Parse(table["finalized"].ToString());
            this.debit = table["debit"].ToString().Equals("") ? 0.00 : Convert.ToDouble(table["debit"]);
            this.credit = table["credit"].ToString().Equals("") ? 0.00 : Convert.ToDouble(table["credit"]);
        }

        /*PROPERTIES*/
        public int Id
        {
            get { return this.id; }
        }

        public Customer Customer
        {
            get {
                if (!this.customerloaded)
                {
                    if (this.customerid == 0)
                    {
                        this.customer = new Customer();
                    }
                    else
                    {
                        this.customer = new Customer(customerid);
                    }
                    this.customerid = this.customer.Id;
                    this.customername = this.customer.Name;
                    this.customerloaded = true;
                }
                return this.customer; 
            }
            set 
            { 
                this.customer = value;
                this.customerid = this.customer.Id;
                this.customername = this.customer.Name;
                this.customerloaded = true;
            }
        }
        public String CustomerName
        {
            get { return this.customername; }
        }
        public String RepName
        {
            get { return this.repname; }
        }

        public DateTime Date
        {
            get { return this.datetime; }
            set { this.datetime = value; }
        }
        public PaymentType PaymentDue
        {
            get { return this.paymentdue; }
            set { this.paymentdue = value; }
        }
        public InvoiceProduct[] Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public String Instructions
        {
            get { return this.instructions; }
            set { this.instructions = value; }
        }

        public Boolean Finalized
        {
            get { return this.finalized; }
            set { this.finalized = value; }
        }

        public String CreatedBy
        {
            get { return this.createdby; }
            set { this.createdby = value; }
        }

        public Double Balance
        {
            get {
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

        public double SubTotal
        {
            get
            {
                calculateInvoiceTotals();
                return this.subtotal;
            }
        }
        public double VAT
        {
            get
            {
                calculateInvoiceTotals();
                return this.vat;
            }
        }

        public double GrandTotal
        {
            get
            {
                calculateInvoiceTotals();
                return this.subtotal + this.vat;
            }
        }

        public String HTML
        {
            get { return getHTML(false); }
        }
        public String HTMLPreview
        {
            get { return getHTML(true); }
        }


        private String getHTML(Boolean preview)
        {
            Hashtable mergefields = new Hashtable();
            
            //Note that we use the customer property, as the customer is only loaded from the property
            mergefields.Add("customer_name", this.Customer.Name);
            mergefields.Add("customer_street", this.Customer.Street);
            mergefields.Add("customer_city", this.Customer.City);
            mergefields.Add("customer_zip", this.Customer.Zipcode);
            mergefields.Add("customer_vat", this.Customer.VatNumber);
            mergefields.Add("customer_phone", this.Customer.Phone);
            mergefields.Add("customer_fax", this.Customer.Fax);
            mergefields.Add("customer_email", this.Customer.EmailAddress);
            mergefields.Add("customer_contact", this.Customer.Contact);
            mergefields.Add("customer_rep", this.Customer.Rep.FriendlyName);

            mergefields.Add("invoice_number", this.id);
            mergefields.Add("invoice_instructions", this.instructions);
            mergefields.Add("invoice_date", this.datetime.ToShortDateString());
            mergefields.Add("invoice_finalized", this.finalized.ToString());

            calculateInvoiceTotals();
            mergefields.Add("subtotal", Utilities.MakeMoneyValue(subtotal));
            mergefields.Add("vat", Utilities.MakeMoneyValue(vat));
            mergefields.Add("total", Utilities.MakeMoneyValue(subtotal + vat));

            //Create invoice entries
            HashSet<String[]> tablerows = calculateInvoiceTotals();

            String template = "invoice";
            if (preview) template = "invoice_preview";
            HTML html = new HTML(template, "Invoice " + this.id, mergefields);
            html.AddHTML("entries", html.CreateHTMLTableRows(tablerows, false));
            return html.ToString();
        }

        private HashSet<String[]> calculateInvoiceTotals()
        {
            this.vat = 0;
            this.subtotal = 0;
            HashSet<String[]> tablerows = new HashSet<string[]>();
            //tablerows.Add(new String[] { "WEIGHT (KG)", "DESCRIPTION", "PRICE PER KG", "AMOUNT" });
            foreach (InvoiceProduct product in this.products)
            {
                double producttotal = product.Quantity * product.Price;
                double productvat = 0;
                if (product.HasVat)
                {
                    productvat = producttotal * 14 / 100;
                    this.vat += productvat;
                }
                tablerows.Add(new String[] { product.Quantity.ToString(), product.Name, Utilities.MakeMoneyValue(product.Price), Utilities.MakeMoneyValue(System.Math.Round(producttotal + productvat, 2)) });

                this.subtotal += System.Math.Round(producttotal, 2);
            }
            return tablerows;
        }

    }
}
