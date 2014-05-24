using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trexis.Finance.Manager
{
    public partial class statementForm : Form
    {
        private Context context;
        private Statement statement;

        public statementForm(Context context, Statement statement)
        {
            this.context = context;
            this.statement = statement;

            InitializeComponent();
            populateFields();
        }

        public statementForm(Context context, Customer customer, Boolean zerobased)
        {
            this.context = context;

            InitializeComponent();

            this.statement = new Statement(customer, zerobased);
            populateFields();
        }

        public statementForm(Context context, Customer customer, DateTime startdate, DateTime enddate)
        {
            this.context = context;

            InitializeComponent();

            this.statement = new Statement(customer, false, startdate, enddate);
            populateFields();
        }

        private void populateFields()
        {
            loadList();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void statementForm_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[*title*]", this.statement.Customer.Name);
            labelOpeningBalance.Text = Utilities.MakeMoneyValue(this.statement.OpeningBalance);
            labelClosingBalance.Text = Utilities.MakeMoneyValue(this.statement.ClosingBalance);
        }

        private void loadList()
        {

            try
            {
                listView.Items.Clear();

                HashSet<String[]> listentries = this.statement.listEntries();
                foreach (String[] listentry in listentries)
                {
                    ListViewItem listitem = new ListViewItem();
                    listitem.Text = listentry[0];
                    listitem.SubItems.Add(listentry[1]);
                    listitem.SubItems.Add(listentry[2]);
                    listitem.SubItems.Add(listentry[3]);
                    listitem.SubItems.Add(listentry[4]);
                    listitem.SubItems.Add(listentry[5]);
                    listView.Items.Add(listitem);
                }

            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load list of invoices\n" + ex.Message);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            performPrint();
        }

        private void performPrint()
        {
            Printer printer = new Printer(this.context, this);
            printer.Print(statement.HTML);
        }

    }
}
