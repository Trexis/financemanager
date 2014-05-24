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
    public partial class userForm : Form
    {
        private User user;
        private Context context;


        public userForm(Context context)
        {
            this.context = context;

            InitializeComponent();
            user = new User();
            populateFields();
        }
        public userForm(Context context, User user)
        {
            this.context = context;

            InitializeComponent();
            this.user = user;
            populateFields();
        }

        private void populateFields()
        {
            textBoxUsername.Text = user.Username;
            textBoxPassword.Text = user.Password;
            textBoxName.Text = user.Name;
            textBoxSurname.Text = user.Surname;
            textBoxEmail.Text = user.EmailAddress;
            textBoxPhone.Text = user.PhoneNumber;
            comboBoxRole.SelectedIndex = Convert.ToInt16(user.Role) - 1;

            textBoxUsername.Enabled = Security.allowUserManagement(this.context.User);
            comboBoxRole.Enabled = Security.allowUserManagement(this.context.User);
        }

        private void user_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[*username*]", user.Username);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {

                user.Username = textBoxUsername.Text;
                user.Password = textBoxPassword.Text;
                user.Name = textBoxName.Text;
                user.Surname = textBoxSurname.Text;
                user.EmailAddress = textBoxEmail.Text;
                user.PhoneNumber = textBoxPhone.Text;
                user.Role = (Roles)(comboBoxRole.SelectedIndex + 1);
                user.Save();
                this.Close();
            }
            catch (Exception ex)
            {
                Tools.ShowError("Unable to save user. \n" + ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonViewPassword_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxPassword.PasswordChar = '\0';
        }

        private void buttonViewPassword_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxPassword.PasswordChar = Convert.ToChar("*");
        }
    }
}
