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
    public partial class customerForm : Form
    {
        private Customer customer;
        private Context context;


        public customerForm(Context context)
        {
            this.context = context;

            InitializeComponent();
            customer = new Customer();
            populateFields();
        }
        public customerForm(Context context, Customer customer)
        {
            this.context = context;

            InitializeComponent();
            this.customer = customer;
            populateFields();
        }

        private void populateFields()
        {
            textBoxName.Text = customer.Name;
            textBoxStreet.Text = customer.Street;
            textBoxCity.Text = customer.City;
            textBoxZip.Text = customer.Zipcode;
            textBoxVat.Text = customer.VatNumber;
            textBoxPhone.Text = customer.Phone;
            textBoxFax.Text = customer.Fax;
            textBoxEmail.Text = customer.EmailAddress;
            textBoxContact.Text = customer.Contact;
            comboBoxPaymentType.SelectedIndex = Convert.ToInt16(customer.PaymentType);
            loadListReps(customer.Rep);
        }

        private void loadListReps(User rep)
        {
            try
            {
                comboBoxRep.Items.Clear();
                comboBoxRep.DisplayMember = "FriendlyName";
                comboBoxRep.ValueMember = "Id"; 
                User[] items = Manager.listUsers();
                foreach (User item in items)
                {
                    int index = comboBoxRep.Items.Add(item);
                    if (rep != null)
                    {
                        if (item.Id == rep.Id)
                        {
                            comboBoxRep.SelectedIndex = index;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load list of reps\n" + ex.Message);
            }
        }


        private void customer_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[*customername*]", customer.Name);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textBoxName.Text.Equals("") && !textBoxVat.Text.Equals("") && !textBoxContact.Text.Equals("") && !textBoxPhone.Text.Equals("") && (comboBoxRep.SelectedIndex>0))
                {
                    customer.Name = textBoxName.Text;
                    customer.Street = textBoxStreet.Text;
                    customer.City = textBoxCity.Text;
                    customer.Zipcode = textBoxZip.Text;
                    customer.Phone = textBoxPhone.Text;
                    customer.Fax = textBoxFax.Text;
                    customer.VatNumber = textBoxVat.Text;
                    customer.EmailAddress = textBoxEmail.Text;
                    customer.Contact = textBoxContact.Text;
                    customer.Rep = (User)comboBoxRep.Items[comboBoxRep.SelectedIndex];
                    customer.PaymentType = (PaymentType)comboBoxPaymentType.SelectedIndex;
                    customer.Save();
                    this.Close();
                }
                else
                {
                    Tools.ShowError("Not all mandatory fields completed");
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to save customer. \n" + ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
