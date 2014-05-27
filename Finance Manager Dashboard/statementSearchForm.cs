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
    public partial class statementSearchForm : Form
    {
        private Context context;
        private Customer customer;

        public statementSearchForm(Context context, Customer customer)
        {
            this.context = context;

            InitializeComponent();
            this.customer = customer;
            
            populateFields();
        }

        private void populateFields()
        {
            labelCustomer.Text = customer.Name;
            labelBalance.Text = Utilities.MakeMoneyValue(customer.Balance);
            dateTimePickerStart.Value = DateTime.Now.AddMonths(-1);
            enableDateSelect(radioButtonDateRange.Checked);
            buttonEmail.Visible = Security.allowEmail(this.context.User);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void statementForm_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[*customername*]", customer.Name);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            enableDateSelect(radioButtonDateRange.Checked);
        }

        private void enableDateSelect(Boolean enabled)
        {
            dateTimePickerStart.Enabled = enabled;
            dateTimePickerEnd.Enabled = enabled;
            labelStartDate.Enabled = enabled;
            labelEndDate.Enabled = enabled;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                Statement statement = getStatement();
                statementForm form = new statementForm(this.context, statement);
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to generate statement\n" + ex.Message);
            }

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Statement statement = getStatement();
                Printer printer = new Printer(this.context, this);
                printer.PrintForm(statement.HTML);
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to print statement\n" + ex.Message);
            }
        }

        private Statement getStatement()
        {
            if (radioButtonDateRange.Checked)
            {
                return new Statement(this.customer, false, dateTimePickerStart.Value, dateTimePickerEnd.Value);
            }
            else if (radioButtonLastZero.Checked)
            {
                return new Statement(this.customer, true);
            }
            else
            {
                return new Statement(this.customer, false);
            }
        }

        private void buttonEmail_Click(object sender, EventArgs e)
        {
            Email email = new Email();
            Statement statement = getStatement();

            DateTime enddate = DateTime.Now;
            DateTime begindate = DateTime.Now.AddMonths(-1);
            begindate = new DateTime(begindate.Year, begindate.Month, 1);

            if (radioButtonDateRange.Checked)
            {
                begindate = dateTimePickerStart.Value;
                enddate = dateTimePickerEnd.Value;
            }

            if (email.Send(this.customer.EmailAddress, this.customer.Name, "MeulenFoods Statement: " + begindate.ToShortDateString() + "-" + enddate.ToShortDateString(), statement.EmailHTML))
            {
                Tools.ShowInfo("Statement email sent to " + this.customer.Name + " [" + this.customer.EmailAddress + "]");
            }
            else
            {
                Tools.ShowError(email.ErrorMessage);
            }
        }
    }
}
