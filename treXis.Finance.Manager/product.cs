using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trexis.Finance.Manager
{
    public class Product
    {
        private int id;
        private String name = "";
        private Double price = 0;
        private Boolean instock = true;
        private Boolean hasvat = true;
        private Double vatpercentage = 0;

        private Dal dal;

        public Product()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load product", ex);
            }
        }


        public Product(Hashtable userresult)
        {
            try
            {
                populateFromResultTable(userresult);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load product", ex);
            }
        }

        public Product(int id)
        {
            try
            {
                dal = new Dal();
                HashSet<Hashtable> results = dal.executeAsHashset("call getProductById(" + id + ");");
                populateFromResults(results);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load product by id " + id, ex);
            }
        }

        public void Save()
        {
            try
            {
                if (this.name.Equals("")) throw new Exception("Name mandatory");

                dal = new Dal();
                HashSet<Hashtable> results = dal.executeAsHashset("call updateProduct('" + this.name + "', " + this.price + ", " + Convert.ToInt16(this.instock) + "," + this.vatpercentage + ");");
                populateFromResults(results);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to save product", ex);
            }
        }

        public void Delete()
        {
            try
            {
                dal = new Dal();
                dal.executeNonQuery("call deleteProduct(" + this.Id + ");");
                this.id = 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to delete product", ex);
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
            this.price = Convert.ToDouble(table["price"]);
            this.instock = Convert.ToBoolean(table["instock"]);
            this.vatpercentage = Convert.ToDouble(table["vatpercentage"]);
            this.hasvat = (vatpercentage > 0);
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
        public Double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public Boolean InStock
        {
            get { return this.instock; }
            set { this.instock = value; }
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
    }
}
