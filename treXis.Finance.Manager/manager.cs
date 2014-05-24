using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trexis.Finance.Manager
{
    public static class Manager
    {
        public static User[] listUsers(Roles role)
        {
            User[] users = new User[0];

            Dal dal = new Dal();
            HashSet<Hashtable> results = dal.executeAsHashset("call listUsers(" + Convert.ToInt16(role) + ");");
            users = new User[results.Count];
            int counter = 0;
            foreach (Hashtable table in results)
            {
                User user = new User(table);
                users[counter] = user;
                counter++;
            }
            return users;
        }

        public static User[] listUsers()
        {
            User[] users = new User[0];

            Dal dal = new Dal();
            HashSet<Hashtable> results = dal.executeAsHashset("call listUsers(null);");
            users = new User[results.Count];
            int counter = 0;
            foreach (Hashtable table in results)
            {
                User user = new User(table);
                users[counter] = user;
                counter++;
            }
            return users;
        }

        public static Customer[] listCustomers()
        {
            Customer[] customers = new Customer[0];

            Dal dal = new Dal();
            HashSet<Hashtable> results = dal.executeAsHashset("call listCustomers();");
            customers = new Customer[results.Count];
            int counter = 0;
            foreach (Hashtable table in results)
            {
                Customer customer = new Customer(table);
                customers[counter] = customer;
                counter++;
            }
            return customers;
        }

        public static Hashtable listSearchCustomers()
        {
            Hashtable customers = new Hashtable();

            Dal dal = new Dal();
            HashSet<Hashtable> results = dal.executeAsHashset("call listCustomers();");
            foreach (Hashtable table in results)
            {
                customers.Add(table["name"].ToString().ToLower(), table["id"]);
            }
            return customers;
        }

        public static Hashtable listSearchProducts()
        {
            Hashtable products = new Hashtable();

            Dal dal = new Dal();
            HashSet<Hashtable> results = dal.executeAsHashset("call listProducts();");
            foreach (Hashtable table in results)
            {
                products.Add(table["name"].ToString().ToLower(), table["id"]);
            }
            return products;
        }


        public static Product[] listProducts()
        {
            Product[] products = new Product[0];

            Dal dal = new Dal();
            HashSet<Hashtable> results = dal.executeAsHashset("call listProducts();");
            products = new Product[results.Count];
            int counter = 0;
            foreach (Hashtable table in results)
            {
                Product product = new Product(table);
                products[counter] = product;
                counter++;
            }
            return products;
        }


        public static Invoice[] listInvoices()
        {
            Invoice[] invoices = new Invoice[0];

            Dal dal = new Dal();
            HashSet<Hashtable> results = dal.executeAsHashset("call listInvoices();");
            invoices = new Invoice[results.Count];
            int counter = 0;
            foreach (Hashtable table in results)
            {
                Invoice invoice = new Invoice(table);
                invoices[counter] = invoice;
                counter++;
            }
            return invoices;
        }

        public static Invoice[] listInvoices(DateTime startDate, DateTime endDate, String customer)
        {
            Invoice[] invoices = new Invoice[0];

            Dal dal = new Dal();

            String startdate = startDate.Year + "-" + startDate.Month + "-" + startDate.Day;
            String enddate = endDate.Year + "-" + endDate.Month + "-" + endDate.Day;

            String query = "";
            if ((customer != null)&&(!customer.Equals("")))
            {
                query = "call listInvoicesByDateAndCustomer('" + startdate + "','" + enddate + "','%" + customer + "%');";
            }
            else
            {
                query = "call listInvoicesByDateAndCustomer('" + startdate + "','" + enddate + "',null);";
            }
            HashSet<Hashtable> results = dal.executeAsHashset(query);
            invoices = new Invoice[results.Count];
            int counter = 0;
            DateTime now = DateTime.Now;
            foreach (Hashtable table in results)
            {
                Invoice invoice = new Invoice(table);
                invoices[counter] = invoice;
                counter++;
            }
            DateTime after = DateTime.Now;
            //now.Subtract(after)
            return invoices;
        }

        public static Boolean debug
        {
            get {
                Config config = new Config();
                String debug = config.GetSetting("debug");
                return Convert.ToBoolean(debug);
            }
        }
    }
}
