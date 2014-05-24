using System;
using System.Collections;
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
    public partial class invoiceForm : Form
    {
        private Invoice invoice;
        private Context context;

        private Hashtable searchcustomers = new Hashtable();

        public invoiceForm(Context context)
        {
            this.context = context;

            InitializeComponent();
            invoice = new Invoice();

            searchcustomers = Manager.listSearchCustomers();
            loadCustomersList();

            enableCustomerFields();
            buttonPrint.Visible = buttonSave.Visible = Security.allowInvoiceManagement(context.User);

            populateInvoiceFields(invoice);
            loadListProducts();
            populateCustomerFields(invoice.Customer);
        }
        public invoiceForm(Context context, Invoice invoice)
        {
            this.context = context;

            InitializeComponent();
            this.invoice = invoice;

            searchcustomers = Manager.listSearchCustomers();
            loadCustomersList();

            buttonSave.Enabled = buttonSavePrint.Enabled = Security.allowInvoiceManagement(context.User);
            buttonAddProduct.Enabled = buttonEditProduct.Enabled = buttonRemoveProduct.Enabled = Security.allowInvoiceManagement(context.User);

            populateInvoiceFields(invoice);
            loadListProducts();
            populateCustomerFields(invoice.Customer);
        }


        private void enableCustomerFields(){
            textBoxStreet.Enabled = textBoxCity.Enabled = textBoxZip.Enabled = textBoxContact.Enabled = textBoxVat.Enabled = textBoxPhone.Enabled = textBoxFax.Enabled = textBoxEmail.Enabled = comboBoxPaymentType.Enabled = comboBoxRep.Enabled = Security.allowCustomerManagement(this.context.User);
        }

        private void loadCustomersList()
        {
            foreach (String key in searchcustomers.Keys)
            {
                comboBoxCustomers.Items.Add(Utilities.CapitalizeWord(key));
            }
        }


        private void populateInvoiceFields(Invoice invoice)
        {
            dateTimePickerInvoiceDate.Value = invoice.Date;
            textBoxInstructions.Text = invoice.Instructions;
        }

        private void loadListProducts()
        {
            try
            {
                InvoiceProduct[] products = invoice.Products;
                foreach (InvoiceProduct item in products)
                {
                    ListViewItem listitem = createItem(item);
                    listView1.Items.Add(listitem);
                }
                calculateTotals();
                enableDelete((listView1.SelectedItems.Count > 0));
                enableEdit((listView1.SelectedItems.Count > 0));
                showHint();
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load list of products\n" + ex.Message);
            }
        }


        private void populateCustomerFields(Customer customer)
        {
            comboBoxCustomers.Text = customer.Name;
            textBoxStreet.Text = customer.Street;
            textBoxCity.Text = customer.City;
            textBoxZip.Text = customer.Zipcode;
            textBoxVat.Text = customer.VatNumber;
            textBoxPhone.Text = customer.Phone;
            textBoxFax.Text = customer.Fax;
            textBoxContact.Text = customer.Contact;
            textBoxEmail.Text = customer.EmailAddress;
            comboBoxPaymentType.SelectedIndex = Convert.ToInt16(customer.PaymentType);
            calculateDueDate();
            loadListReps(customer.Rep);
        }

        private void invoice_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[*invoicenumber*]", invoice.Id.ToString()).Replace("[*customername*]", invoice.Customer.Name).Replace("[*date*]",invoice.Date.ToShortDateString());
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveInvoice())
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to save invoice. \n" + ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void searchCustomers(String searchText)
        {
            labelExist.Visible = false;
            String searchvalue = searchText.ToLower();
            if (searchcustomers.ContainsKey(searchvalue))
            {
                labelExist.Visible = true;
                int customerid = Convert.ToInt16(searchcustomers[searchvalue]);
                if (invoice.Customer.Id != customerid)
                {
                    invoice.Customer = new Customer(customerid);
                    populateCustomerFields(invoice.Customer);
                }
            }
            else
            {
                invoice.Customer = new Customer();
            }
        }

        private void buttonSavePrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveInvoice())
                {
                    buttonSave.Enabled = buttonSavePrint.Enabled = Security.allowInvoiceManagement(context.User);
                    buttonAddProduct.Enabled = buttonEditProduct.Enabled = buttonRemoveProduct.Enabled = Security.allowInvoiceManagement(context.User);

                    performPrint();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to save invoice. \n" + ex.Message);
            }
        }

        private Boolean saveInvoice()
        {
            Boolean success = false;
            if (!comboBoxCustomers.Text.Equals("") && !textBoxVat.Text.Equals("") && !textBoxContact.Text.Equals("") && !textBoxPhone.Text.Equals(""))
            {
                Customer customer = invoice.Customer;
                if (Security.allowCustomerManagement(context.User))
                {
                    if(customer.Id==0) customer.Name = comboBoxCustomers.Text;
                    customer.Street = textBoxStreet.Text;
                    customer.City = textBoxCity.Text;
                    customer.Zipcode = textBoxZip.Text;
                    customer.Phone = textBoxPhone.Text;
                    customer.Fax = textBoxFax.Text;
                    customer.VatNumber = textBoxVat.Text;
                    customer.Contact = textBoxContact.Text;
                    customer.EmailAddress = textBoxEmail.Text;
                    customer.PaymentType = (PaymentType)comboBoxPaymentType.SelectedIndex;
                    customer.Rep = (User)comboBoxRep.Items[comboBoxRep.SelectedIndex];
                    customer.Save();
                }

                if (invoice.Customer.Id != 0)
                {
                    if ((invoice.Id == 0)||(invoice.CreatedBy.Equals(""))) invoice.CreatedBy = context.User.Username;
                    invoice.Date = dateTimePickerInvoiceDate.Value;
                    invoice.Instructions = textBoxInstructions.Text;
                    invoice.PaymentDue = (PaymentType)comboBoxPaymentType.SelectedIndex;
                    invoice.Save();
                    success = true;
                }
                else
                {
                    Tools.ShowError("Customer name required");
                }
            }
            else
            {
                Tools.ShowError("All mandatory fields required");
            }
            return success;
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            addProduct();
        }

        private void addProduct()
        {
            selectProductForm form = new selectProductForm(context);
            form.ShowDialog(this);

            InvoiceProduct invoiceproduct = form.InvoiceProduct;
            if (!invoiceproduct.Name.Equals(""))
            {
                ListViewItem item = new ListViewItem();
                listView1.Items.Add(createItem(invoiceproduct));
                calculateTotals();
            }
            enableDelete((listView1.SelectedItems.Count > 0));
            enableEdit((listView1.SelectedItems.Count > 0));
            showHint();
        }

        private ListViewItem createItem(InvoiceProduct invoiceproduct)
        {
            ListViewItem item = new ListViewItem();
            item.Text = invoiceproduct.Quantity.ToString();
            item.SubItems.Add(invoiceproduct.Name);
            item.SubItems.Add(Utilities.MakeMoneyValue(invoiceproduct.Price));
            item.SubItems.Add(Utilities.MakeMoneyValue(System.Math.Round(invoiceproduct.Price*invoiceproduct.Quantity,2)));
            Double vat = 0;
            if (invoiceproduct.HasVat)
            {
                vat = invoiceproduct.Price * invoiceproduct.Quantity * 14 / 100;
            }
            item.SubItems.Add(Utilities.MakeMoneyValue(System.Math.Round(vat, 2)));
            item.SubItems.Add(Utilities.MakeMoneyValue(System.Math.Round((invoiceproduct.Quantity * invoiceproduct.Price)+vat, 2)));
            return item;
        }

        private void calculateTotals()
        {
            Double subtotal = 0;
            double vat = 0;
            invoice.Products = new InvoiceProduct[listView1.Items.Count];
            int counter = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                InvoiceProduct product = new InvoiceProduct();
                product.Name = item.SubItems[1].Text;
                product.Price = Convert.ToDouble(item.SubItems[2].Text);
                product.Quantity = Convert.ToDouble(item.Text);

                subtotal += Double.Parse(item.SubItems[3].Text);
                vat += Double.Parse(item.SubItems[4].Text);
                if (vat > 0) product.HasVat = true;

                invoice.Products[counter] = product;
                counter++;
            }
            
            textBoxSubTotal.Text = Utilities.MakeMoneyValue(System.Math.Round(subtotal,2));
            textBoxVATTotal.Text = Utilities.MakeMoneyValue(System.Math.Round(vat,2));
            textBoxGrandTotal.Text = Utilities.MakeMoneyValue(System.Math.Round(subtotal + vat,2));
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDelete((listView1.SelectedItems.Count > 0));
            enableEdit((listView1.SelectedItems.Count > 0));
        }

        private void enableDelete(Boolean enabled)
        {
            buttonRemoveProduct.Enabled = enabled;
        }

        private void enableEdit(Boolean enabled)
        {
            buttonEditProduct.Enabled = enabled;
        }

        private void buttonEditProduct_Click(object sender, EventArgs e)
        {
            editSelection();
        }

        private void editSelection()
        {
            try
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    InvoiceProduct invoiceproduct = new InvoiceProduct();
                    invoiceproduct.Quantity = Convert.ToDouble(item.Text);
                    invoiceproduct.Name = item.SubItems[1].Text.ToString();
                    invoiceproduct.Price = Convert.ToDouble(item.SubItems[2].Text);

                    selectProductForm form = new selectProductForm(this.context, invoiceproduct);
                    form.ShowDialog(this);
                    invoiceproduct = form.InvoiceProduct;
                    if (!invoiceproduct.Name.Equals(""))
                    {
                        item.SubItems.Clear();
                        item.Text = invoiceproduct.Quantity.ToString();
                        item.SubItems.Add(invoiceproduct.Name);
                        item.SubItems.Add(Utilities.MakeMoneyValue(invoiceproduct.Price));
                        item.SubItems.Add(Utilities.MakeMoneyValue(System.Math.Round(invoiceproduct.Price * invoiceproduct.Quantity, 2)));
                        Double vat = 0;
                        if (invoiceproduct.HasVat)
                        {
                            vat = invoiceproduct.Price * invoiceproduct.Quantity * 14 / 100;
                        }
                        item.SubItems.Add(Utilities.MakeMoneyValue(System.Math.Round(vat, 2)));
                        item.SubItems.Add(Utilities.MakeMoneyValue(System.Math.Round((invoiceproduct.Quantity * invoiceproduct.Price) + vat, 2)));
                        calculateTotals();
                    }
                }
                enableDelete((listView1.SelectedItems.Count > 0));
                enableEdit((listView1.SelectedItems.Count > 0));
                showHint();
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load product\n" + ex.Message);
            }
        }

        private void buttonRemoveProduct_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                item.Remove();
                calculateTotals();
            }
            enableDelete((listView1.SelectedItems.Count > 0));
            enableEdit((listView1.SelectedItems.Count > 0));
            showHint();
        }

        private void listView1_Enter(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                editSelection();
            }
            else
            {
                addProduct();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            editSelection();
        }

        private void comboBoxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCustomers.SelectedIndex > -1)
            {
                searchCustomers(comboBoxCustomers.Text);
            }
        }

        private void comboBoxCustomers_TextChanged(object sender, EventArgs e)
        {
            searchCustomers(comboBoxCustomers.Text);
        }

        private void showHint()
        {
            panel1.Visible = (listView1.Items.Count == 0);
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

        private void comboBoxPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateDueDate();
        }

        private void calculateDueDate()
        {
            switch ((PaymentType)comboBoxPaymentType.SelectedIndex)
            {
                case PaymentType.COD:
                    labelDue.Text = dateTimePickerInvoiceDate.Value.ToLongDateString();
                    break;
                case PaymentType.SevenDays:
                    labelDue.Text = dateTimePickerInvoiceDate.Value.AddDays(7).ToLongDateString();
                    break;
                case PaymentType.FourteenDays:
                    labelDue.Text = dateTimePickerInvoiceDate.Value.AddDays(14).ToLongDateString();
                    break;
                case PaymentType.ThirtyDays:
                    labelDue.Text = dateTimePickerInvoiceDate.Value.AddMonths(1).ToLongDateString();
                    break;
                default:
                    labelDue.Text = "";
                    break;
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            Printer printer = new Printer(this.context, this);
            printer.PrintPreview(invoice.HTML);
        }

        private void performPrint()
        {
            Printer printer = new Printer(this.context, this);
            printer.PrintForm(invoice.HTMLPreview, invoice.HTML);  //we do printform, otherwise the form unloads before printpreview shown
        }
    }
}
