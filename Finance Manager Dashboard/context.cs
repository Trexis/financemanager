using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trexis.Finance.Manager
{
    public class Context
    {
        private User user = null;
        private Form primaryform = null; 

        public Context(Form primaryForm, User user)
        {
            this.primaryform = primaryForm;
            this.user = user;
        }
        
        public Context(User user)
        {
            this.user = user;
        }

        public User User
        {
            get { return this.user; }
            set { this.user = value; }
        }
        public Form PrimaryForm
        {
            get { return this.primaryform; }
            set { this.primaryform = value; }
        }
    }
}
