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
    public partial class paymentForm : Form
    {
        private Context context;
        private Customer customer;
        private Invoice invoice = null;
        private Payment payment;

        public paymentForm(Context context, Customer customer)
        {
            this.context = context;

            InitializeComponent();
            this.customer = customer;
            payment = new Payment(customer);
            
            populateFields();
        }
        public paymentForm(Context context, Invoice invoice)
        {
            this.context = context;

            InitializeComponent();
            this.invoice = invoice;
            this.customer = invoice.Customer;
            payment = new Payment(invoice);

            populateFields();
        }

        private void populateFields()
        {
            labelCustomer.Text = customer.Name;
            labelBalance.Text = Utilities.MakeMoneyValue(customer.Balance);
            dateTimePicker.Value = DateTime.Now;
            if (invoice != null)
            {
                textBoxAmount.Text = Utilities.MakeMoneyValue(invoice.Balance);
                labelInvoice.Text = invoice.Id + " [" + invoice.Date.ToShortDateString() + "]";
            }
            else
            {
                textBoxAmount.Text = Utilities.MakeMoneyValue(customer.Balance);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void paymentForm_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[*customername*]", customer.Name);
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            try{
                if (textBoxAmount.Text.Equals("")) throw new Exception("Amount required");

                if ((Convert.ToDouble(textBoxAmount.Text) < 1) && (!Security.allowCredits(this.context.User)))
                {
                    throw new Exception("A positive amount required, only certain users can add credit notes");
                }

                if (Convert.ToDouble(textBoxAmount.Text) > this.customer.Balance)
                {
                    if (MessageBox.Show("The amount entered is more than what this customers outstanding balance is.  Do you want to continue?", "Customer Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        payment.Pay(Convert.ToDouble(textBoxAmount.Text), dateTimePicker.Value);
                    }
                }
                else
                {
                    payment.Pay(Convert.ToDouble(textBoxAmount.Text), dateTimePicker.Value);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to make payment. \n" + ex.Message);
            }
        }
    }
}
