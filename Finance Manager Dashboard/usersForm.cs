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
    public partial class usersForm : Form
    {
        private Context context;


        public usersForm(Context context)
        {
            this.context = context;

            InitializeComponent();

            this.Text = this.Text.Replace("[*companyname*]", Properties.Settings.Default.companyname);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            userForm form = new userForm(this.context);
            form.ShowDialog(this);
            loadList();
        }

        private void usersForm_Load(object sender, EventArgs e)
        {
            loadList();
        }

        private void loadList()
        {
            try
            {
                listView.Items.Clear();
                User[] items = Manager.listUsers();
                foreach (User item in items)
                {
                    ListViewItem listitem = new ListViewItem();
                    listitem.Text = item.Username;
                    listitem.SubItems.Add(item.Role.ToString());
                    listitem.Tag = item.Id;
                    listView.Items.Add(listitem);
                }
                enableDelete((listView.SelectedItems.Count > 0));
                enableEdit((listView.SelectedItems.Count > 0));
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load list of users\n" + ex.Message);
            }
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
                    int userid = Convert.ToInt16(item.Tag);
                    if (userid.Equals(context.User.Id))
                    {
                        Tools.ShowError("You can not delete the logged in user");
                    }
                    else
                    {
                        User user = new User(userid);
                        if(MessageBox.Show(this, "Are you sure you want to delete " + user.Username + "?", Properties.Settings.Default.companyname, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            user.Delete();
                            loadList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to delete user\n" + ex.Message);
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
                    User user;
                    if (id.Equals(context.User.Id))
                    {
                        user = context.User;
                    }
                    else
                    {
                        user = new User(id);
                    }
                    userForm form = new userForm(this.context, user);
                    form.ShowDialog(this);
                    loadList();
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to load user\n" + ex.Message);
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
    }
}
