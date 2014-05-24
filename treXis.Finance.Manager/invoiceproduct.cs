using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trexis.Finance.Manager
{
    public class InvoiceProduct
    {
        private String name = "";
        private Double price = 0;
        private Double quantity = 0;
        private Product product;
        private Boolean hasvat = false;
        private Double vatpercentage = 0;

        public InvoiceProduct()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load invoice product", ex);
            }
        }


        public InvoiceProduct(Hashtable result)
        {
            try
            {
                populateFromResultTable(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load invoice product", ex);
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
            this.name = table["name"].ToString();
            this.price = Convert.ToDouble(table["price"]);
            this.quantity = Convert.ToDouble(table["quantity"]);
            this.vatpercentage = Convert.ToDouble(table["vatpercentage"]);
            this.hasvat = (this.vatpercentage > 0);
        }

        /*PROPERTIES*/
        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public Double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public Double Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }
        public Boolean HasVat
        {
            get { return this.hasvat; }
            set {
                this.hasvat = value;
                if (value)
                {
                    this.vatpercentage = 14;
                }
                else
                {
                    this.vatpercentage = 0;
                }
            }
        }
        public Product Product
        {
            get { return this.product; }
            set { this.product = value; }
        }
    }
}
