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
    public partial class productsForm : Form
    {
        private Context context;
        private Product[] items = new Product[0];


        public productsForm(Context context)
        {
            this.context = context;

            InitializeComponent();

            this.Text = this.Text.Replace("[*companyname*]", Properties.Settings.Default.companyname);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            productForm form = new productForm(this.context);
            form.ShowDialog(this);
            loadList();
        }

        private void productsForm_Load(object sender, EventArgs e)
        {
            loadList();
        }

        private void loadList()
        {
            try
            {
                items = Manager.listProducts();
                filterList(textBoxFilter.Text);
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load list of products\n" + ex.Message);
            }
        }

        private void filterList(String filter)
        {
            listView.Items.Clear();
            foreach (Product item in items)
            {
                if (filter.Equals("") || item.Name.ToLower().Contains(filter.ToLower()))
                {
                    ListViewItem listitem = new ListViewItem();
                    listitem.Text = item.Name;
                    listitem.SubItems.Add(Utilities.MakeMoneyValue(item.Price));
                    listitem.Tag = item.Id;
                    listView.Items.Add(listitem);
                }
            }
            enableDelete((listView.SelectedItems.Count > 0));
            enableEdit((listView.SelectedItems.Count > 0));
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
                    Product product = new Product(id);
                    if(MessageBox.Show(this, "Are you sure you want to delete " + product.Name + "?", Properties.Settings.Default.companyname, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        product.Delete();
                        loadList();
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to delete product\n" + ex.Message);
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDelete((listView.SelectedItems.Count > 0));
            enableEdit((listView.SelectedItems.Count > 0));
        }

        private void enableDelete(Boolean enabled)
        {
            buttonDelete.Enabled = enabled;
        }

        private void enableEdit(Boolean enabled)
        {
            buttonEdit.Enabled = enabled;
        }

        private void editSelection()
        {
            try
            {
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    int id = Convert.ToInt16(item.Tag);
                    Product product = new Product(id);
                    productForm form = new productForm(this.context, product);
                    form.ShowDialog(this);
                    loadList();
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load product\n" + ex.Message);
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
            filterList(textBoxFilter.Text);
        }


    }
}
