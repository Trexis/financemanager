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
    public partial class invoicesForm : Form
    {
        private Context context;
        private Invoice[] items = new Invoice[0];
        private Boolean firstload = true;

        public invoicesForm(Context context)
        {
            this.context = context;

            InitializeComponent();

            buttonNew.Visible = Security.allowInvoiceCreate(this.context.User);
            buttonEdit.Visible = buttonDelete.Visible = Security.allowInvoiceManagement(this.context.User);
            buttonPayment.Visible = Security.allowPayments(this.context.User);
            buttonFinalize.Visible = Security.allowFinalize(this.context.User);
            buttonEmail.Visible = Security.allowEmail(this.context.User);

            this.Text = this.Text.Replace("[*companyname*]", Properties.Settings.Default.companyname);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            invoiceForm form = new invoiceForm(this.context);
            form.ShowDialog(this);
            loadList();
        }

        private void invoicesForm_Load(object sender, EventArgs e)
        {
            dateTimePickerEnd.Value = DateTime.Now;
            dateTimePickerStart.Value = DateTime.Now.AddMonths(-1);
            if (this.context.User.Role == Roles.Rep)
            {
                textBoxRepFilter.Text = this.context.User.Name;
            }
            loadList();
            firstload = false;
        }

        private void loadList()
        {
            try
            {
                items = Manager.listInvoices(dateTimePickerStart.Value, dateTimePickerEnd.Value, textBoxCustomerFilter.Text);
                listView.Items.Clear();
                foreach (Invoice item in items)
                {
                    if (textBoxRepFilter.Text.Equals("") || item.Customer.Rep.FriendlyName.ToLower().Contains(textBoxRepFilter.Text.ToLower()))
                    {
                        ListViewItem listitem = new ListViewItem();
                        listitem.Text = item.Id.ToString();
                        listitem.SubItems.Add(item.CustomerName);
                        listitem.SubItems.Add(item.Date.ToShortDateString());
                        listitem.SubItems.Add(item.RepName);
                        listitem.SubItems.Add(item.CreatedBy);
                        listitem.SubItems.Add(Utilities.MakeMoneyValue(item.Debit));
                        listitem.SubItems.Add(Utilities.MakeMoneyValue(item.Credit));
                        listitem.SubItems.Add(Utilities.MakeMoneyValue(item.Balance));
                        listitem.Tag = item.Id;
                        listitem.ToolTipText = item.Finalized ? "Finalized" : "";

                        if ((item.Balance == 0) || item.Finalized)
                        {
                            listitem.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            if(item.PaymentDue.Equals(PaymentType.COD)) {
                                listitem.ForeColor = System.Drawing.Color.Red;
                            } else {
                                DateTime invoiceduedate = item.Date;
                                if (item.PaymentDue.Equals(PaymentType.FourteenDays)) invoiceduedate = invoiceduedate.AddDays(14);
                                if (item.PaymentDue.Equals(PaymentType.SevenDays)) invoiceduedate = invoiceduedate.AddDays(7);
                                if (item.PaymentDue.Equals(PaymentType.ThirtyDays)) invoiceduedate = invoiceduedate.AddDays(30);

                                if (DateTime.Now > invoiceduedate)
                                {
                                    listitem.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                        }


                        listView.Items.Add(listitem);
                    }
                }
                enableDelete((listView.SelectedItems.Count > 0));
                enableEdit((listView.SelectedItems.Count > 0));
                enablePrint((listView.SelectedItems.Count > 0));
                enablePayment((listView.SelectedItems.Count > 0));
                enableFinalize((listView.SelectedItems.Count > 0));
                enableEmail((listView.SelectedItems.Count > 0));
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load list of invoices\n" + ex.Message);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try{
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    int id = Convert.ToInt16(item.Tag);
                    Invoice invoice = new Invoice(id);
                    if(MessageBox.Show(this, "Are you sure you want to delete " + invoice.Id + "?", Properties.Settings.Default.companyname, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        invoice.Delete();
                        loadList();
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to delete invoice\n" + ex.Message);
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDelete((listView.SelectedItems.Count > 0));
            enableEdit((listView.SelectedItems.Count > 0));
            enablePrint((listView.SelectedItems.Count > 0));
            enablePayment((listView.SelectedItems.Count > 0));
            enableFinalize((listView.SelectedItems.Count > 0));
            enableEmail((listView.SelectedItems.Count > 0));
        }

        private void enableDelete(Boolean enabled)
        {
            buttonDelete.Enabled = enabled;
        }

        private void enableEmail(Boolean enabled)
        {
            buttonEmail.Enabled = enabled;
        }

        private void enableEdit(Boolean enabled)
        {
            buttonEdit.Enabled = enabled;
        }

        private void enablePrint(Boolean enabled)
        {
            buttonPrint.Enabled = enabled;
        }

        private void enablePayment(Boolean enabled)
        {
            buttonPayment.Enabled = enabled;
        }

        private void enableFinalize(Boolean enabled)
        {
            foreach (ListViewItem item in listView.SelectedItems)
            {
                if (item.ToolTipText.Contains("Finalized"))
                {
                    buttonFinalize.Text = "Unfinalize";
                }
                else
                {
                    buttonFinalize.Text = "Finalize";
                }
            }
            buttonFinalize.Enabled = enabled;
        }

        private void listView_Enter(object sender, EventArgs e)
        {
            editSelection();
        }

        private void editSelection()
        {
            try
            {
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    int id = Convert.ToInt16(item.Tag);
                    Invoice invoice = new Invoice(id);
                    invoiceForm form = new invoiceForm(this.context, invoice);
                    form.ShowDialog(this);
                    loadList();
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load invoice\n" + ex.Message);
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
            if (!firstload) loadList();
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if(!firstload) loadList();
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            if (!firstload) loadList();
        }

        private void textBoxRepFilter_TextChanged(object sender, EventArgs e)
        {
            if (!firstload) loadList();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    int id = Convert.ToInt16(item.Tag);
                    Invoice invoice = new Invoice(id);
                    Printer printer = new Printer(this.context, this);
                    printer.PrintPreview(invoice.HTML);
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to print invoice\n" + ex.Message);
            }
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    int id = Convert.ToInt16(item.Tag);
                    Invoice invoice = new Invoice(id);
                    paymentForm form = new paymentForm(this.context, invoice);
                    form.ShowDialog(this);
                    loadList();
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load invoice to perform payment\n" + ex.Message);
            }
        }

        private void buttonFinalize_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    int id = Convert.ToInt16(item.Tag);
                    Invoice invoice = new Invoice(id);
                    if(MessageBox.Show("Are you sure you want to " + buttonFinalize.Text + " the invoice " + invoice.Id + "?", "Finalize/Unfinalize Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes){
                        invoice.Finalized = buttonFinalize.Text.Equals("Finalize") ? true : false;
                        invoice.Save();
                        loadList();
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load invoice to perform finalize\n" + ex.Message);
            }
        }

        private void buttonEmail_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    int id = Convert.ToInt16(item.Tag);
                    Invoice invoice = new Invoice(id);
                    if (!invoice.Customer.EmailAddress.Equals(""))
                    {
                        Email email = new Email();
                        if (email.Send(invoice.Customer.EmailAddress, invoice.Customer.Name, "MeulenFoods Invoice " + invoice.Id, invoice.HTMLEmail))
                        {
                            Tools.ShowInfo("Invoice email sent to " + invoice.Customer.Name + " [" + invoice.Customer.EmailAddress + "]");
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
                Tools.ShowError("Unable to load invoice to perform email\n" + ex.Message);
            }

        }


    }
}
