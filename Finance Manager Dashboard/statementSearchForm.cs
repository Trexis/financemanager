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
    }
}
