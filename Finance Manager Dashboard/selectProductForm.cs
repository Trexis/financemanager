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
    public partial class selectProductForm : Form
    {
        private InvoiceProduct invoiceproduct;
        private Context context;
        Hashtable searchproducts = new Hashtable();

        public selectProductForm(Context context)
        {
            this.context = context;

            InitializeComponent();

            searchproducts = Manager.listSearchProducts();
            loadProductsList();

            invoiceproduct = new InvoiceProduct();
            invoiceproduct.Product = new Product();
            
            populateFields(invoiceproduct);
        }
        public selectProductForm(Context context, InvoiceProduct invoiceproduct)
        {
            this.context = context;

            InitializeComponent();
            
            searchproducts = Manager.listSearchProducts();
            loadProductsList();

            this.invoiceproduct = invoiceproduct;
            populateFields(invoiceproduct);
        }

        private void loadProductsList()
        {
            foreach (String key in searchproducts.Keys)
            {
                comboBoxProducts.Items.Add(Utilities.CapitalizeWord(key));
            }
        }

        private void populateFields(Product product)
        {
            comboBoxProducts.Text = product.Name;
            if (invoiceproduct.Price == 0)
            {
                textBoxPrice.Text = product.Price.ToString();
            }
        }
        private void populateFields(InvoiceProduct product)
        {
            comboBoxProducts.Text = product.Name;
            textBoxPrice.Text = product.Price.ToString();
            textBoxQuantity.Text = product.Quantity.ToString(); 
        }


        private void selectproduct_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[*productname*]", invoiceproduct.Name);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!comboBoxProducts.Text.Equals(""))
                {
                    double price = 0;
                    if (double.TryParse(textBoxPrice.Text, out price))
                    {
                        double quantity = 0;
                        if (double.TryParse(textBoxQuantity.Text, out quantity))
                        {
                            invoiceproduct.Name = comboBoxProducts.Text;
                            invoiceproduct.Price = price;
                            invoiceproduct.Quantity = quantity;
                            
                            /*if (Utilities.allowProductManagement(context.User))
                            {
                                if (invoiceproduct.Product.Id == 0)
                                {
                                    invoiceproduct.Product.Name = invoiceproduct.Name;
                                    invoiceproduct.Product.Price = invoiceproduct.Price;
                                    invoiceproduct.Product.Save();
                                }
                            }*/
                            this.Close();
                        }
                        else
                        {
                            Tools.ShowError("Not a valid quantity");
                        }
                    }
                    else
                    {
                        Tools.ShowError("Not a valid amount");
                    }
                }
                else
                {
                    Tools.ShowError("Product name required");
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to save product. \n" + ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void searchProduct(String name)
        {
            labelExist.Visible = false;
            String searchvalue = name.ToLower();
            if (searchproducts.ContainsKey(searchvalue))
            {
                labelExist.Visible = true;
                int productid = Convert.ToInt16(searchproducts[searchvalue]);
                invoiceproduct.Product = new Product(productid);
                invoiceproduct.HasVat = invoiceproduct.Product.HasVat;
                populateFields(invoiceproduct.Product);
            }
            else
            {
                invoiceproduct.Product = new Product();
            }
        }

        public InvoiceProduct InvoiceProduct
        {
            get { return this.invoiceproduct; }
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            calculateTotal();
        }

        private void calculateTotal()
        {
            labelSubTotal.Text = "0.00";
            labelVat.Text = "0.00";
            labelGrandTotal.Text = "0.00";

            double price = 0;
            if (double.TryParse(textBoxPrice.Text, out price))
            {
                double quantity = 0;
                if (double.TryParse(textBoxQuantity.Text, out quantity))
                {
                    double subtotal = price * quantity;
                    labelSubTotal.Text = System.Math.Round(subtotal,2).ToString();
                    if (invoiceproduct.HasVat)
                    {
                        labelVat.Text = System.Math.Round(subtotal * 14 / 100,2).ToString();
                        labelGrandTotal.Text = System.Math.Round(subtotal+(subtotal*14/100), 2).ToString();
                    }
                    else
                    {
                        labelVat.Text = "0.00";
                        labelGrandTotal.Text = labelSubTotal.Text;
                    }
                }
            }

        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            calculateTotal();
        }

        private void comboBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProducts.SelectedIndex > -1)
            {
                searchProduct(comboBoxProducts.Items[comboBoxProducts.SelectedIndex].ToString());
            }
        }

        private void comboBoxProducts_TextChanged(object sender, EventArgs e)
        {
            searchProduct(comboBoxProducts.Text);
        }
    }
}
