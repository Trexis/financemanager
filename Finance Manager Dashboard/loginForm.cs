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
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[*company*]", Properties.Settings.Default.companyname);

            if (Manager.debug)
            {
                textBoxPassword.Text = "admin";
                textBoxUsername.Text = "admin";
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User(textBoxUsername.Text);
                if (user.ValidatePassword(textBoxPassword.Text))
                {
                    textBoxPassword.Text = "";
                    formDashboard form = new formDashboard(new Context(this, user));
                    form.Show();
                    this.Hide();
                }
                else
                {
                    throw new Exception("Invalid password");
                }
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to login" + "\n" + ex.Message);
            }
        }

        private void textBoxUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxUsername.Text.Equals(""))
                {
                    Tools.ShowInfo("Username should not be empty");
                }
                else
                {
                    textBoxPassword.Focus();
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                buttonExit_Click(sender, e);
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(sender, e);
            }
        }

    }
}
