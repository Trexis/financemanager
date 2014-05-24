using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trexis.Finance.Manager
{
    public partial class formDashboard : Form
    {
        Boolean islogout = false;
        private Context context;


        public formDashboard(Context context)
        {
            this.context = context;
            InitializeComponent();
        }

        private void formDashboard_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[*companyname*]",Properties.Settings.Default.companyname);
            toolStripStatusLabelLoggedinAs.Text = toolStripStatusLabelLoggedinAs.Text.Replace("[*username*]", context.User.Name + " " + context.User.Surname + " [" + context.User.Username + "]");


            toolStripButtonNewInvoice.Visible = Security.allowInvoiceCreate(context.User);

            toolStripButtonCustomers.Visible = Security.allowCustomersList(context.User);
            toolStripButtonInvoices.Visible = Security.allowInvoicesList(context.User);
            toolStripButtonProducts.Visible = Security.allowProductsList(context.User);
            toolStripSeparator1.Visible = (toolStripButtonCustomers.Visible && toolStripButtonInvoices.Visible && toolStripButtonProducts.Visible);

            toolStripButtonUsers.Visible = Security.allowUsersList(context.User);
            toolStripSeparator2.Visible = (toolStripButtonUsers.Visible);

            toolStripDropDownButtonReports.Visible = Security.allowReportsIncomeExpenses(context.User) || Security.allowReportsProducts(context.User);
            incomeexpenseReportToolStripMenuItem.Visible = Security.allowReportsIncomeExpenses(context.User);
            productSalesReportToolStripMenuItem.Visible = Security.allowReportsProducts(context.User);
            toolStripSeparator3.Visible = (toolStripDropDownButtonReports.Visible);

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAboutbox form = new formAboutbox();
            form.ShowDialog(this);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islogout = true;
            this.Close();
            context.PrimaryForm.Show();
        }

        private void formDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!islogout)
            {
                Application.Exit();
            }
            else {
                islogout = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void profiletoolStripMenuItem_Click(object sender, EventArgs e)
        {
            userForm form = new userForm(context, context.User);
            form.ShowDialog(this);
        }

        private void toolStripButtonUsers_Click(object sender, EventArgs e)
        {
            usersForm form = new usersForm(context);
            form.ShowDialog(this);
        }

        private void toolStripButtonCustomers_Click(object sender, EventArgs e)
        {
            customersForm form = new customersForm(context);
            form.ShowDialog(this);
        }

        private void toolStripButtonProducts_Click(object sender, EventArgs e)
        {
            productsForm form = new productsForm(context);
            form.ShowDialog(this);
        }

        private void toolStripButtonNewInvoice_Click(object sender, EventArgs e)
        {
            invoiceForm form = new invoiceForm(context);
            form.ShowDialog(this);
        }

        private void toolStripButtonInvoices_Click(object sender, EventArgs e)
        {
            invoicesForm form = new invoicesForm(context);
            form.ShowDialog(this);
        }

        private void incomeExpenseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportsForm form = new reportsForm(context, ReportType.IncomeExpenses);
            form.Show(this);
        }

        private void productSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportsForm form = new reportsForm(context, ReportType.ProductSales);
            form.Show(this);
        }

        private void toolStripDropDownButtonReports_Click(object sender, EventArgs e)
        {

        }

    }
}
