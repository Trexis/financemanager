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
    public partial class productForm : Form
    {
        private Product product;
        private Context context;


        public productForm(Context context)
        {
            this.context = context;

            InitializeComponent();
            product = new Product();
            populateFields();
        }
        public productForm(Context context, Product product)
        {
            this.context = context;

            InitializeComponent();
            this.product = product;
            populateFields();
        }

        private void populateFields()
        {
            textBoxName.Text = product.Name;
            textBoxPrice.Text = product.Price.ToString();
            checkBoxInStock.Checked = product.InStock;
            checkBoxHasVat.Checked = !product.HasVat;
        }

        private void product_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[*productname*]", product.Name);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                double price = 0;
                if (double.TryParse(textBoxPrice.Text, out price))
                {
                    product.Name = textBoxName.Text;
                    product.Price = price;
                    product.InStock = checkBoxInStock.Checked;
                    product.HasVat = !checkBoxHasVat.Checked;
                    product.Save();
                    this.Close();
                }
                else
                {
                    Tools.ShowError("Not a valid amount");
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
    }
}
