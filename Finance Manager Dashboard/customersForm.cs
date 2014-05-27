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
    public partial class customersForm : Form
    {
        private Context context;
        private Customer[] items = new Customer[0];


        public customersForm(Context context)
        {
            this.context = context;

            InitializeComponent();

            buttonEdit.Visible = buttonDelete.Visible = Security.allowCustomerManagement(context.User);
            buttonPayment.Visible = Security.allowPayments(context.User);
            buttonStatement.Visible = Security.allowStatementsList(context.User);
            buttonEmail.Visible = Security.allowEmail(context.User);

            this.Text = this.Text.Replace("[*companyname*]", Properties.Settings.Default.companyname);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            customerForm form = new customerForm(this.context);
            form.ShowDialog(this);
            loadList();
        }

        private void customersForm_Load(object sender, EventArgs e)
        {
            loadList();
        }

        private void loadList()
        {
            try
            {
                items = Manager.listCustomers();
                filterList(textBoxFilterCustomer.Text, textBoxFilterRep.Text);
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load list of customers\n" + ex.Message);
            }
        }

        private void filterList(String customerFilter, String repFilter)
        {
            listView.Items.Clear();
            foreach (Customer item in items)
            {
                if ((customerFilter.Equals("") && repFilter.Equals("")) || (item.Name.ToLower().Contains(customerFilter.ToLower()) && item.Rep.FriendlyName.ToLower().Contains(repFilter.ToLower())))
                {
                    ListViewItem listitem = new ListViewItem();
                    listitem.Text = item.Name;
                    listitem.SubItems.Add(item.Phone);
                    listitem.SubItems.Add(item.Rep.FriendlyName);
                    listitem.SubItems.Add(Utilities.MakeMoneyValue(item.Debit));
                    listitem.SubItems.Add(Utilities.MakeMoneyValue(item.Credit));
                    listitem.SubItems.Add(Utilities.MakeMoneyValue(item.Balance));
                    listitem.Tag = item.Id;
                    listView.Items.Add(listitem);
                }
            }
            enableDelete((listView.SelectedItems.Count > 0));
            enableEdit((listView.SelectedItems.Count > 0));
            enablePayment((listView.SelectedItems.Count > 0));
            enableStatement((listView.SelectedItems.Count > 0));
            enableEmail((listView.SelectedItems.Count > 0));
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (ListViewItem item in listView.SelectedItems)
                {
                    int id = Convert.ToInt16(item.Tag);
                    Customer customer = new Customer(id);
                    if (customer.InvoiceCount == 0)
                    {
                        if (MessageBox.Show(this, "Are you sure you want to delete " + customer.Name + "?", Properties.Settings.Default.companyname, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            customer.Delete();
                            loadList();
                        }
                    }
                    else
                    {
                        Tools.ShowInfo("Customer has " + customer.InvoiceCount + " invoices, can not delete this customer");
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to delete customer\n" + ex.Message);
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDelete((listView.SelectedItems.Count > 0));
            enableEdit((listView.SelectedItems.Count > 0));
            enablePayment((listView.SelectedItems.Count > 0));
            enableStatement((listView.SelectedItems.Count > 0));
            enableEmail((listView.SelectedItems.Count > 0));
        }

        private void enableDelete(Boolean enabled)
        {
            buttonDelete.Enabled = enabled;
        }

        private void enableEdit(Boolean enabled)
        {
            buttonEdit.Enabled = enabled;
        }
        private void enableEmail(Boolean enabled)
        {
            buttonEmail.Enabled = enabled;
        }

        private void enablePayment(Boolean enabled)
        {
            if (Security.allowPayments(context.User))
            {
                buttonPayment.Enabled = enabled;
            }
        }
        private void enableStatement(Boolean enabled)
        {
            if (Security.allowStatementsList(context.User))
            {
                buttonStatement.Enabled = enabled;
            }
        }

        private void editSelection()
        {
            try
            {
                if(Security.allowCustomerManagement(this.context.User)){
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        int id = Convert.ToInt16(item.Tag);
                        Customer customer = new Customer(id);
                        customerForm form = new customerForm(this.context, customer);
                        form.ShowDialog(this);
                        loadList();
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load customer\n" + ex.Message);
            }
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            editSelection();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            editSelection();
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            filterList(textBoxFilterCustomer.Text, textBoxFilterRep.Text);
        }

        private void textBoxFilterRep_TextChanged(object sender, EventArgs e)
        {
            filterList(textBoxFilterCustomer.Text, textBoxFilterRep.Text);
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to pay the customer without selecting a invoice?", "Payment direct to customer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        int id = Convert.ToInt16(item.Tag);
                        Customer customer = new Customer(id);
                        paymentForm form = new paymentForm(this.context, customer);
                        form.ShowDialog(this);
                        loadList();
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load customer to perform payment\n" + ex.Message);
            }
        }

        private void buttonStatement_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    int id = Convert.ToInt16(item.Tag);
                    Customer customer = new Customer(id);
                    statementSearchForm form = new statementSearchForm(this.context, customer);
                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load customer to load statement\n" + ex.Message);
            }
        }

        private void buttonEmail_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    int id = Convert.ToInt16(item.Tag);
                    Customer customer = new Customer(id);
                    if (!customer.EmailAddress.Equals(""))
                    {
                        DateTime enddate = DateTime.Now;
                        DateTime begindate = DateTime.Now.AddMonths(-1);
                        begindate = new DateTime(begindate.Year, begindate.Month, 1);
                        Statement statement = new Statement(customer, true, begindate, enddate);

                        Email email = new Email();
                        if (email.Send(customer.EmailAddress, customer.Name, "MeulenFoods Statement: " + begindate.ToShortDateString() + "-" + enddate.ToShortDateString(), statement.EmailHTML))
                        {
                            Tools.ShowInfo("Statement email sent to " + customer.Name + " [" + customer.EmailAddress + "]");
                        }
                        else
                        {
                            Tools.ShowError(email.ErrorMessage);
                        }
                        
                    }
                    else
                    {
                        Tools.ShowInfo("Customer does not have a email address, update the customer email address first.");
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load customer\n" + ex.Message);
            }

        }


    }
}
